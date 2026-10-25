using System.Net;
using System.Text.Json;
using ControleFinanceiro.Application.Common.Exceptions;
using FluentValidation;

namespace ControleFinanceiro.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException exception)
        {
            await TratarErroDeValidacaoAsync(context, exception);
        }
        catch (NotFoundException exception)
        {
            await TratarRecursoNaoEncontradoAsync(context, exception);
        } 
        catch(UnauthorizedAccessException exception)
        {
            await TratarNaoAutorizadoAsync(context, exception);
        }
        catch (Exception exception)
        {
            await TratarErroInternoAsync(context, exception);
        }
    }

    private static async Task TratarNaoAutorizadoAsync(HttpContext context, UnauthorizedAccessException exception)
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;

        context.Response.ContentType = "application/json";

        var resposta = new
        {
            status = StatusCodes.Status401Unauthorized,
            titulo = "Não autorizado.",
            detalhe = "Credenciais invalidas ou expiradas."
        };
    }

    private static async Task TratarErroDeValidacaoAsync(
        HttpContext context,
        ValidationException exception)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        context.Response.ContentType = "application/json";

        var erros = exception.Errors.GroupBy(erro => erro.PropertyName)
            .ToDictionary(
                grupo => grupo.Key,
                grupo => grupo
                    .Select(erro => erro.ErrorMessage)
                    .Distinct()
                    .ToArray());

        var resposta = new
        {
            status = StatusCodes.Status400BadRequest,
            titulo = "Erro de validação.",
            erros
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(resposta));
    }

    private static async Task TratarRecursoNaoEncontradoAsync(HttpContext context, NotFoundException exception)
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;

        context.Response.ContentType = "application/json";

        var resposta = new 
        {
            status = StatusCodes.Status404NotFound,
            titulo = "Recurso não encontrado.",
            detalhe = exception.Message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(resposta));
    }

    private async Task TratarErroInternoAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "Ocorreu um erro inesperado durante a requisição.");

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Response.ContentType = "application/json";

        var resposta = new
        {
            status = StatusCodes.Status500InternalServerError,
            titulo = "Erro interno do servidor.",
            detalhe = "Ocorreu um erro inesperado."
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(resposta));
    }
}