using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Category
{
    // Category fields
    private string name;
    private string description;
    private string type;

    // constructor for Category
    public Category(string name, string description, string type)
    {
        this.name = name;
        this.description = description;
        this.type = type;
    }

    // empty Category constructor
    public Category() { }

    // properties of Category
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public string Type
    {
        get { return type; }
        set { type = value; }
    }
}