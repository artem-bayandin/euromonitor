﻿using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Common.CommandResults
{
    public enum CommandResultStatuses
    {
        Success,
        BadRequest,
        ServerError
    }

    public class CommandResult
    {
        protected bool _hasError;

        public bool HasError => _hasError || Validation?.Errors != null && Validation.Errors.Any();

        public ValidationResult Validation { get; set; }

        public int StatusCode { get; protected set; }

        // just for tests
        public CommandResult()
        {
        }

        public static CommandResult Ok()
        {
            var result = new CommandResult
            {
                StatusCode = (int)CommandResultStatuses.Success
            };
            return result;
        }

        public static CommandResult FailedValidation(IList<ValidationFailure> errors)
        {
            var result = new CommandResult
            {
                StatusCode = (int)CommandResultStatuses.BadRequest,
                _hasError = true,
                Validation = new ValidationResult()
            };
            foreach (var error in errors)
            {
                result.Validation.Errors.Add(error);
            }
            return result;
        }
    }

    public class CommandResult<TResult> : CommandResult
    //where TResult : class
    {
        public readonly TResult Result;

        // just for tests
        public CommandResult()
        {
        }

        private CommandResult(TResult result)
        {
            Result = result;
        }

        public static CommandResult<TResult> Ok(TResult result)
        {
            return new CommandResult<TResult>(result)
            {
                StatusCode = (int)CommandResultStatuses.Success
            };
        }

        public new static CommandResult<TResult> FailedValidation(IList<ValidationFailure> errors)
        {
            var result = new CommandResult<TResult>(default)
            {
                StatusCode = (int)CommandResultStatuses.BadRequest,
                _hasError = true,
                Validation = new ValidationResult()
            };
            foreach (var error in errors)
            {
                result.Validation.Errors.Add(error);
            }
            return result;
        }
    }
}
