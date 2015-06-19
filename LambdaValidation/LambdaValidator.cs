namespace DecoratorValidation.LambdaValidation
{
    using System;

    using DecoratorValidation.Core;

    public class LambdaValidator<T> : ValidatorDecorator<T>
    {
        private readonly Func<T, bool> predicate;
        private string _errorMessage;

        public LambdaValidator(Validator<T> a, Func<T,bool> predicate, string ErrorMessage) : base(a) 
        {
            this._errorMessage = ErrorMessage;
            this.predicate = predicate;
        }

        public override bool Validate(T toValidate)
        {
            this.isValid = this.predicate(toValidate);
            this.AppendErrorMessage(this._errorMessage);
            return this.isValid && base.Validate(toValidate);
        }
    }
}
