namespace Simon.Rules
{
    /// <summary>
    /// Defines a rule for an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of te entity.</typeparam>
    public interface IRule<TEntity>
    {
        /// <summary>
        /// Determines whether the rule is applicable for the current state of the entity.
        /// </summary>
        /// <param name="entiry">The entity instance.</param>
        /// <returns>
        /// <c>true</c> if the rule is applicable for the
        /// current state of the entity, otherwise; <c>false</c>.
        /// </returns>
        bool IsApplicable(TEntity entiry);

        /// <summary>
        /// Checks and returns the status of the rule for the current state of the entity.
        /// </summary>
        /// <param name="entiry">The entity instance.</param>
        /// <returns>The rule status.</returns>
        RuleStatus CheckStatus(TEntity entiry);
    }
}