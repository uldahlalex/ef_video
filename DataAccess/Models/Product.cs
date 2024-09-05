using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;
}
