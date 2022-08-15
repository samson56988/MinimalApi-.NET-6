using DataAccess.Data;
using DataAccess.Models;

namespace MinimalApi
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet(pattern: "/Users", GetUsers);
            app.MapGet(pattern: "/Users/{Id}", GetUser);
            app.MapPost(pattern: "/Users", InsertUser);
            app.MapPut(pattern: "/Users", UpdateUser);
            app.MapDelete(pattern: "/Users", DeleteUser);
        }

        private static async Task<IResult> GetUsers(IUserData data)
        {
            try
            {
                return Results.Ok(await data.GetUsers());
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetUser(int Id, IUserData data)
        {
            try 
            {

                var results = await data.GetUser(Id);
                if (results == null) return Results.NotFound();
                    return Results.Ok(results);
            
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertUser(UserModel user, IUserData data)
        {
            try
            {
                await data.InsertUser(user);
                return Results.Ok();

            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdateUser(UserModel user,IUserData data)
        {
            try
            {
                await data.UpdateUser(user);
                return Results.Ok();    
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteUser(int Id, IUserData data)
        {

            try
            {
                await data.DeleteUser(Id);
                return Results.Ok();
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
    }
}
