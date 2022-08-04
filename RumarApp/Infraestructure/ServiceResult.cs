using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumarApp.Infraestructure
{
    public class ServiceResult<TResult> : ServiceResult
    {
        public ServiceResult()
        {

        }

        public ServiceResult(IValidatableEntity validatableEntity) : base(validatableEntity)
        {

        }

        public ServiceResult(ServiceResult serviceResult)
        {
            AddErrorMessages(serviceResult);
        }

        public TResult Data { get; set; }

        public static ServiceResult<TResult> Create(IValidatableEntity validatableEntity = null)
        {
            return validatableEntity != null ?
            new ServiceResult<TResult>(validatableEntity) :
            new ServiceResult<TResult>();
        }
    }

    public class ServiceResult
    {
        public ServiceResult()
        {

        }

        public ServiceResult(IValidatableEntity validatableEntity)
        {
            AddErrorMessages(validatableEntity.Validate());
        }

        public bool ExecutedSuccesfully { get; set; } = true;

        public string Message
        {
            get
            {
                var builder = new StringBuilder();

                foreach (var message in Messages)
                {
                    builder.AppendLine(message);
                }

                return builder.ToString();
            }
        }

        public Exception Exception { get; set; }

        public List<string> Messages { get; } = new List<string>();

        public void AddErrorMessage(string message)
        {
            ExecutedSuccesfully = false;
            AddMessage(message);
        }

        public void AddErrorMessages(ServiceResult serviceResult)
        {
            serviceResult.Messages.ForEach(AddErrorMessage);
        }

        public void AddErrorMessages(List<string> errorMessages)
        {
            errorMessages.ForEach(AddErrorMessage);
        }

        public void AddErrorMessages(ValidationResult validationResult)
        {
            if (validationResult.IsValid) return;

            foreach (var validationFailure in validationResult.Errors)
            {
                AddErrorMessage(validationFailure.ErrorMessage);
            }
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }

        public ServiceResult CopyChildMessages(ServiceResult serviceResult)
        {
            if (serviceResult == null) return this;

            AddErrorMessages(serviceResult.Messages);

            return this;
        }

        public static ServiceResult Create()
        {
            return new ServiceResult();
        }

        public static ServiceResult CreateAndValidate(IValidatableEntity validatableEntity)
        {
            return new ServiceResult(validatableEntity);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            Messages.ForEach(x => builder.AppendLine(x));

            if (Exception != null)
                builder.AppendLine(Exception.ToString());

            return builder.ToString();
        }

    }
}
