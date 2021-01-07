using Dapper;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.QueryHelper;
using SqlKata;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RecipeRepository : BaseRepository<Recipe, RecipeBookContext>
    {
        private readonly ISqlQueryHelper _queryHelper;

        public RecipeRepository(RecipeBookContext context, ISqlQueryHelper sqlQueryHelper) : base(context)
        {
            _queryHelper = sqlQueryHelper;
        }

        public async Task<IEnumerable<Recipe>> GetRecipesWithRelations()
        {
            var query = GetRecipesQuery();

            var recipeQuery = _queryHelper.Compile(query);

            var recipes = await _queryHelper.Connection.QueryAsync<Recipe>(recipeQuery);

            foreach (var item in recipes)
            {
                item.RecipeIngredients = _queryHelper.Connection.Query<RecipeIngredient>(_queryHelper.Compile(GetRecipeIngredientsQuery(item.Id))).ToList();
                item.RecipeTags = _queryHelper.Connection.Query<RecipeTag>(_queryHelper.Compile(GetRecipeTagsQuery(item.Id))).ToList();

                foreach (var recipeTag in item.RecipeTags)
                {
                    recipeTag.Tag = _queryHelper.Connection.QueryFirstOrDefault<Tag>(_queryHelper.Compile(GetTagQuery(recipeTag.TagId)));
                }

                item.RecipeType = _queryHelper.Connection.QueryFirstOrDefault<RecipeType>(_queryHelper.Compile(GetRecipeTypeQuery(item.RecipeTypeId)));
                item.CreatedUser = _queryHelper.Connection.QueryFirstOrDefault<User>(_queryHelper.Compile(GetUserQuery(item.CreatedUserId)));
            }

            return recipes;
        }

        private Query GetRecipesQuery()
        {
            return new Query("Recipe");
        }

        private Query GetRecipeIngredientsQuery(int id)
        {
            return new Query("RecipeIngredient").Where("RecipeId", id);
        }

        private Query GetRecipeTypeQuery(int id)
        {
            return new Query("RecipeType").Where("Id", id);
        }

        private Query GetRecipeTagsQuery(int id)
        {
            return new Query("RecipeTag").Where("RecipeId", id);
        }

        private Query GetUserQuery(int id)
        {
            return new Query("User").Where("Id", id);
        }

        private Query GetTagQuery(int id)
        {
            return new Query("Tag").Where("Id", id);
        }
    }
}
