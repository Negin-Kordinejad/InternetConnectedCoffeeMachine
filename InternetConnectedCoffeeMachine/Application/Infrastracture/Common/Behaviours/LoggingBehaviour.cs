﻿using MediatR;
using System.Diagnostics;

namespace InternetConnectedCoffeeMachine.Application.Infrastracture.Common.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                _logger.LogInformation("Starting request {@RequestName}", typeof(TResponse).Name);

                var response = await next();

                stopwatch.Stop();

                _logger.LogInformation("Compeleted request {@RequestName} in {@ElapsedMilliseconds} milliseconds", typeof(TResponse).Name, stopwatch.ElapsedMilliseconds);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {@RequestName}: {@ErrorMessage}", typeof(TResponse).Name, ex.Message);
                throw;
            }
        }
    }
}