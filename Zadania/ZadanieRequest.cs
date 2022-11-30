using Microsoft.AspNetCore.Mvc;

namespace ZadaniaAPI.Zadania
{
    public static class ZadanieRequest
    {
        public static WebApplication RegisterEndpoints(this WebApplication app)
        {
            app.MapGet("/todos", ZadanieRequest.GetAll);
            app.MapGet("/todos/{id}", ZadanieRequest.GetById);
            app.MapPost("/todos", ZadanieRequest.Create);
            app.MapPut("/todos/{id}", ZadanieRequest.Update);
            app.MapDelete("/todos/{id}", ZadanieRequest.Delete);

            return app;
        }

        public static IResult GetAll(IZadanieService service)
        {
            var zadanie = service.GetAll();
            return Results.Ok(zadanie);
        }

        public static IResult GetById(IZadanieService service, [FromRoute] Guid id)
        {
            var zadanie = service.GetById(id);
            if (zadanie == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(zadanie);
        }

        public static IResult Create(IZadanieService service, Zadanie zadanie)
        {
            service.Create(zadanie);

            return Results.Created("/todos/" + zadanie.Id, zadanie);
        }

        public static IResult Update(IZadanieService service, Guid id)
        {
            var zadanie = service.GetById(id);
            if (zadanie == null)
            {
                return Results.NotFound();
            }

            service.Update(id);

            return Results.NoContent();
        }

        public static IResult Delete(IZadanieService service, Guid id)
        {
            var zadanie = service.GetById(id);
            if (zadanie == null)
            {
                return Results.NotFound();
            }

            service.Delete(id);

            return Results.NoContent();
        }
    }
}
