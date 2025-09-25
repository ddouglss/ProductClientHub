using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {

        public ResponseClientJson Execute(ResquestClientJson resquest)
        {
            var validator = new RegisterClientValidator();

            var result = validator.Validate(resquest);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }

            return new ResponseClientJson();
        }

    }
}
