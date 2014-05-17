using Simon.Domain.Process;
using Simon.Domain.Process.Contexts;
using Simon.Domain.Process.Results;
using Simon.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simon.Domain
{
    /// <summary>
    /// Represents a source control repository.
    /// </summary>
    public sealed class SourceRepository
    {
        private readonly string repoPath;
        private readonly IAsyncProcessFactory asyncProcessFactory;
        private List<SourceRepositoryBranch> branches;

        /// <summary>
        /// Initializes an instance of <see cref="SourceRepository"/> class.
        /// </summary>
        /// <param name="repoPath">The repo path.</param>
        /// <param name="asyncProcessFactory">The asyncProcess factory.</param>
        public SourceRepository(string repoPath, IAsyncProcessFactory asyncProcessFactory)
        {
            Guard.NotNullOrEmptyStringArgument("repoPath", repoPath);
            Guard.NotNullArgument("asyncProcessFactory", asyncProcessFactory);

            this.repoPath = repoPath;
            this.asyncProcessFactory = asyncProcessFactory;
        }

        /// <summary>
        /// Gets or sets the repo path.
        /// </summary>
        public string RepoPath
        {
            get { return repoPath; }
        }

        /// <summary>
        /// Gets the branches.
        /// </summary>
        public IEnumerable<SourceRepositoryBranch> Branches
        {
            get
            {
                if (branches == null)
                {
                    GetExistingBranches();
                    UpdateBranchData();
                }

                return branches.AsReadOnly();
            }
        }

        /// <summary>
        /// Creates a new branch for the given <paramref name="feature"/>.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The instance of <see cref="SourceRepositoryBranch"/>.</returns>
        public SourceRepositoryBranch CreateNewFeatureBranch(Feature feature)
        {
            Guard.NotNullArgument("feature", feature);

            var asyncProcess
                = asyncProcessFactory
                    .CreateAsyncProcess<
                        CreateNewFeatureBranchContext,
                        CreateNewFeatureBranchResult>();

            var createNewFeatureBranchTask
                = asyncProcess.ExecuteAsync(new CreateNewFeatureBranchContext
                {
                    Feature = feature,
                    RepoPath = repoPath
                });

            createNewFeatureBranchTask.Wait();

            var featureBranch = createNewFeatureBranchTask.Result.FeatureBranch;
            featureBranch.Repository = this;
            branches.Add(featureBranch);

            return featureBranch;
        }

        private void GetExistingBranches()
        {
            var asyncProcess
                = asyncProcessFactory
                    .CreateAsyncProcess<
                        GetReposirotyBranchesContext,
                        GetReposirotyBranchesResult>();

            var getReposirotyBranchesTask
                = asyncProcess.ExecuteAsync(new GetReposirotyBranchesContext
                {
                    RepoPath = repoPath
                });

            getReposirotyBranchesTask.Wait();

            branches = getReposirotyBranchesTask.Result.Branches.ToList();
        }

        private void UpdateBranchData()
        {
            Parallel.ForEach(branches, eachBranch =>
            {
                var asyncProcess
                    = asyncProcessFactory
                        .CreateAsyncProcess<
                            GetFeatureForBranchContext,
                            GetFeatureForBranchResult>();

                var getFeatureForBranchTask
                    = asyncProcess.ExecuteAsync(new GetFeatureForBranchContext
                    {
                        Branch = eachBranch
                    });

                getFeatureForBranchTask.Wait();

                eachBranch.Repository = this;
                eachBranch.Feature = getFeatureForBranchTask.Result.Feature;
            });
        }
    }
}