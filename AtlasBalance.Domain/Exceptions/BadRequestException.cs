using System;

namespace AtlasBalance.Domain.Exceptions;

/// <summary>
/// Excepción que se lanza cuando los datos proporcionados en una solicitud son inválidos o incompletos.
/// Corresponde al código HTTP 400 Bad Request.
/// </summary>
public class BadRequestException : Exception
{
    #region Constructors

    /// <summary>
    /// Inicializa una nueva instancia de la excepción BadRequestException sin mensaje.
    /// </summary>
    public BadRequestException() { }

    /// <summary>
    /// Inicializa una nueva instancia de la excepción BadRequestException con un mensaje descriptivo.
    /// </summary>
    /// <param name="message">Mensaje de error que describe la excepción.</param>
    public BadRequestException(string message) : base(message) { }

    /// <summary>
    /// Inicializa una nueva instancia de la excepción BadRequestException con un mensaje y una excepción interna.
    /// </summary>
    /// <param name="message">Mensaje de error que describe la excepción.</param>
    /// <param name="innerException">La excepción interna que causó esta excepción.</param>
    public BadRequestException(string message, Exception innerException) : base(message, innerException) { }

    #endregion
}
