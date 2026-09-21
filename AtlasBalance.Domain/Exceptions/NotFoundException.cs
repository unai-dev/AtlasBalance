using System;

namespace AtlasBalance.Domain.Exceptions;

/// <summary>
/// Excepción que se lanza cuando un recurso solicitado no se encuentra en la base de datos.
/// Corresponde al código HTTP 404 Not Found.
/// </summary>
public class NotFoundException : Exception
{
    #region Constructors

    /// <summary>
    /// Inicializa una nueva instancia de la excepción NotFoundException sin mensaje.
    /// </summary>
    public NotFoundException() { }

    /// <summary>
    /// Inicializa una nueva instancia de la excepción NotFoundException con un mensaje descriptivo.
    /// </summary>
    /// <param name="message">Mensaje de error que describe la excepción.</param>
    public NotFoundException(string message) : base(message) { }

    /// <summary>
    /// Inicializa una nueva instancia de la excepción NotFoundException con un mensaje y una excepción interna.
    /// </summary>
    /// <param name="message">Mensaje de error que describe la excepción.</param>
    /// <param name="innerException">La excepción interna que causó esta excepción.</param>
    public NotFoundException(string message, Exception innerException) : base(message, innerException) { }

    #endregion
}
