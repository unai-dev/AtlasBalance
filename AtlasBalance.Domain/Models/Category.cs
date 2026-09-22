using System;
using System.Collections.Generic;

using AtlasBalance.Domain.Models.Common;

namespace AtlasBalance.Domain.Models;

public class Category : BaseModel
{
    #region Properties

    /// <summary>
    /// Nombre descriptivo de la categoría (ej: Food, Transport, Utilities).
    /// </summary>
    public string Name { get; set; } = null!;

    #endregion

    #region Related Properties

    /// <summary>
    /// Colección de gastos asociados a esta categoría.
    /// </summary>
    public List<Expense> Expenses { get; set; } = new List<Expense>();

    /// <summary>
    /// Colección de transferencias asociadas a esta categoría.
    /// </summary>
    public List<Transfer> Transfers { get; set; } = new List<Transfer>();

    /// <summary>
    /// Colección de grupos de gastos asociados a esta categoría.
    /// </summary>
    public List<ExpensesGroup> ExpensesGroups { get; set; } = new List<ExpensesGroup>();

    #endregion
}
