using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {

        public ResponseShortClientJson Execute(ResquestClientJson resquest)
        {
            Validate(resquest);
            // Lógica para registrar o cliente (exemplo: salvar no banco de dados)
            var dbContext = new ProductClientHubDbContext();

            var entity = new Client
            {
                Name = resquest.Name,
                Email = resquest.Email
            };

            dbContext.Clients.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortClientJson
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        private void Validate(ResquestClientJson resquest)
        {
            var validator = new RegisterClientValidator();

            var result = validator.Validate(resquest);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }

        }

    }
}
