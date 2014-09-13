namespace Simon.Repositories
{
    /// <summary>
    /// Represents a source control repository.
    /// </summary>
    public sealed class SourceControlRepository
    {
        //private readonly GlobalSettings globalSettings;
        //private List<SourceControlBranch> branches;

        ///// <summary>
        ///// Initializes an instance of <see cref="SourceControlRepository"/> class.
        ///// </summary>
        ///// <param name="globalSettings">The global settings.</param>
        //public SourceControlRepository(
        //    GlobalSettings globalSettings)
        //{
        //    Guard.NotNullArgument("globalSettings", globalSettings);

        //    this.globalSettings = globalSettings;
        //}

        ///// <summary>
        ///// Gets the branches.
        ///// </summary>
        //public IEnumerable<SourceControlBranch> Branches
        //{
        //    get
        //    {
        //        if (branches == null)
        //        {
        //            branches = GetExistingBranches(this).ToList();
        //            UpdateBranchData(this);
        //        }

        //        return branches.AsReadOnly();
        //    }
        //}

        ///// <summary>
        ///// Creates a new branch for the given <paramref name="feature"/>.
        ///// </summary>
        ///// <param name="feature">The feature.</param>
        ///// <returns>The instance of <see cref="SourceControlBranch"/>.</returns>
        //[ArgumentsNotNull]
        //public SourceControlBranch CreateNewFeatureBranch(Feature feature)
        //{
        //    var asyncProcess
        //        = asyncProcessFactory
        //            .CreateAsyncProcess<
        //                CreateNewFeatureBranchContext,
        //                CreateNewFeatureBranchResult>(this.globalSettings);

        //    var createNewFeatureBranchTask
        //        = asyncProcess.ExecuteAsync(new CreateNewFeatureBranchContext
        //        {
        //            Feature = feature
        //        });

        //    createNewFeatureBranchTask.Wait();

        //    var featureBranch = createNewFeatureBranchTask.Result.FeatureBranch;
        //    featureBranch.Repository = this;
        //    branches.Add(featureBranch);

        //    return featureBranch;
        //}

        //private static IEnumerable<SourceControlBranch> GetExistingBranches(
        //    SourceControlRepository repository)
        //{
        //    var asyncProcess
        //        = repository
        //            .asyncProcessFactory
        //            .CreateAsyncProcess<
        //                EmptyContext,
        //                GetReposirotyBranchesResult>(repository.globalSettings);

        //    var getReposirotyBranchesTask
        //        = asyncProcess.ExecuteAsync(EmptyContext.Instance);

        //    getReposirotyBranchesTask.Wait();

        //    return getReposirotyBranchesTask.Result.Branches;
        //}

        //private static void UpdateBranchData(
        //    SourceControlRepository repository)
        //{
        //    Parallel.ForEach(repository.branches, eachBranch =>
        //    {
        //        var asyncProcess
        //            = repository
        //                .asyncProcessFactory
        //                .CreateAsyncProcess<
        //                    GetFeatureForBranchContext,
        //                    GetFeatureForBranchResult>(repository.globalSettings);

        //        var getFeatureForBranchTask
        //            = asyncProcess.ExecuteAsync(new GetFeatureForBranchContext
        //            {
        //                Branch = eachBranch
        //            });

        //        getFeatureForBranchTask.Wait();

        //        eachBranch.Repository = repository;
        //        eachBranch.Feature = getFeatureForBranchTask.Result.Feature;
        //    });
        //}
    }
}