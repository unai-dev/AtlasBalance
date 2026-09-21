using System;

namespace AtlasBalance.Domain.Exceptions;

/// <summary>
/// Excepción que se lanza cuando un usuario no tiene permiso para acceder o modificar un recurso.
/// Corresponde al código HTTP 403 Forbidden.
/// </summary>
public class ForbiddenException : Exception
{
    #region Constructors

    /// <summary>
    /// Inicializa una nueva instancia de la excepción ForbiddenException sin mensaje.
    /// </summary>
    public ForbiddenException() { }

    /// <summary>
    /// Inicializa una nueva instancia de la excepción ForbiddenException con un mensaje descriptivo.
    /// </summary>
    /// <param name="message">Mensaje de error que describe la excepción.</param>
    public ForbiddenException(string message) : base(message) { }

    /// <summary>
    /// Inicializa una nueva instancia de la excepción ForbiddenException con un mensaje y una excepción interna.
    /// </summary>
    /// <param name="message">Mensaje de error que describe la excepción.</param>
    /// <param name="innerException">La excepción interna que causó esta excepción.</param>
    public ForbiddenException(string message, Exception innerException) : base(message, innerException) { }

    #endregion
}
