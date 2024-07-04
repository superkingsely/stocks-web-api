﻿using System.ComponentModel.DataAnnotations.Schema;

namespace api;

public class Stock
{
    public int Id { get; set; }
    public string Symbol { get; set; }=string.Empty;
    public string CompanyName { get; set; }=string.Empty;
    // data anotation
    [Column(TypeName ="decimal(18,2)")]
    public decimal Purchase{get;set;}
    [Column(TypeName ="decimal(18,2)")]
    public decimal LastDiv{get;set;}
    public string  Industry { get; set; }=string.Empty;
    // long i.e huge amout of moni or value
    public long MarketCap { get; set; }
    public List<Comment> Comments { get; set; }=new List<Comment>{};
};