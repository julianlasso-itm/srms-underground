using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence
{
  public class SeedsSubSkills
  {
    private static Guid CSharpSkillId = Guid.Parse("6098473e-8156-4328-a5bc-ef7f5af422de");
    private static Guid JavaSkillId = Guid.Parse("51373385-dce2-458c-a06b-9b20625b7702");
    private static Guid PythonSkillId = Guid.Parse("b2d2b1b0-c634-4a22-953e-45227a9af902");
    private static Guid JavaScriptSkillId = Guid.Parse("51137603-5df7-4d2d-8f30-799ef5a7dc12");
    private static Guid HtmlSkillId = Guid.Parse("10a818a6-b3df-41de-a69a-b451380343e5");
    private static Guid CssSkillId = Guid.Parse("0b3c088e-7185-4af6-94e5-bf11e29ce628");
    private static Guid SqlSkillId = Guid.Parse("76a48392-0e58-496a-ae78-562df47896b7");
    private static Guid NoSqlMongoDbSkillId = Guid.Parse("60537445-cb83-45d0-8c80-bf7368bc90c9");
    private static Guid AngularSkillId = Guid.Parse("f1ffa467-0220-487c-8afe-66ca42328365");
    private static Guid ReactSkillId = Guid.Parse("81d1012f-7b0a-421f-86b9-4d47ad266574");
    private static Guid NodeJsSkillId = Guid.Parse("0d63d379-f630-4064-bc9b-70bde09d3801");
    private static Guid SpringBootSkillId = Guid.Parse("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b");

    public static void SeedSubSkills(ModelBuilder modelBuilder)
    {
      var subskills = new List<SubSkillModel>
      {
        new()
        {
          SkillId = CSharpSkillId,
          SubSkillId = Guid.NewGuid(),
          Name = "Conceptos básicos de programación",
          Disabled = false,
        },
        new()
        {
          SkillId = CSharpSkillId,
          SubSkillId = Guid.NewGuid(),
          Name = "Programación orientada a objetos",
          Disabled = false,
        },
        new()
        {
          SkillId = JavaSkillId,
          SubSkillId = Guid.NewGuid(),
          Name = "Conceptos básicos de programación",
          Disabled = false,
        },
        new()
        {
          SkillId = JavaSkillId,
          SubSkillId = Guid.NewGuid(),
          Name = "Play Framework",
          Disabled = false,
        },
        new()
        {
          SkillId = PythonSkillId,
          SubSkillId = Guid.NewGuid(),
          Name = "Django",
          Disabled = false,
        },
        new()
        {
          SkillId = PythonSkillId,
          SubSkillId = Guid.NewGuid(),
          Name = "Flask",
          Disabled = false,
        },
        new()
        {
          SkillId = JavaScriptSkillId,
          SubSkillId = Guid.NewGuid(),
          Name = "Async/Await",
          Disabled = false,
        },
        new()
        {
          SkillId = JavaScriptSkillId,
          SubSkillId = Guid.NewGuid(),
          Name = "ES6",
          Disabled = false,
        },
        new()
        {
          SkillId = HtmlSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Comprensión de la estructura fundamental de un documento HTML, incluyendo <!DOCTYPE>, <html>, <head>, y <body>.",
          Disabled = false,
        },
        new()
        {
          SkillId = HtmlSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Uso de elementos HTML para estructurar contenido, como párrafos (<p>), encabezados (<h1> a <h6>), listas (<ul>, <ol>, <li>), y enlaces (<a>).",
          Disabled = false,
        },
        new()
        {
          SkillId = CssSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Comprensión de la sintaxis básica de CSS para definir estilos, incluyendo la selección de elementos, las propiedades, los valores, y la aplicación de estilos.",
          Disabled = false,
        },
        new()
        {
          SkillId = CssSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Uso de estilos CSS para controlar la apariencia de un documento HTML, incluyendo colores, márgenes, padding, y la posición de elementos.",
          Disabled = false,
        },
        new()
        {
          SkillId = SqlSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Comprensión de la estructura de una base de datos relacional, incluyendo tablas, columnas, y claves primarias y foráneas.",
          Disabled = false,
        },
        new()
        {
          SkillId = SqlSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Uso de SQL para realizar consultas en una base de datos relacional, incluyendo la selección, inserción, actualización, y eliminación de datos.",
          Disabled = false,
        },
        new()
        {
          SkillId = NoSqlMongoDbSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Comprensión de la estructura de una base de datos NoSQL, incluyendo colecciones y documentos.",
          Disabled = false,
        },
        new()
        {
          SkillId = NoSqlMongoDbSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Uso de MongoDB para realizar operaciones CRUD en una base de datos NoSQL, incluyendo la selección, inserción, actualización, y eliminación de documentos.",
          Disabled = false,
        },
        new()
        {
          SkillId = AngularSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Comprende la estructura de un proyecto Angular, incluyendo módulos, componentes, servicios, y rutas.",
          Disabled = false,
        },
        new()
        {
          SkillId = AngularSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Uso de Angular para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de rutas, y la comunicación con servicios.",
          Disabled = false,
        },
        new()
        {
          SkillId = ReactSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Comprende la estructura de un proyecto React, incluyendo componentes, props, y estado.",
          Disabled = false,
        },
        new()
        {
          SkillId = ReactSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Uso de React para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de estado, y la comunicación con servicios.",
          Disabled = false,
        },
        new()
        {
          SkillId = NodeJsSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Comprende la estructura de un proyecto Node.js, incluyendo módulos, rutas, y middleware.",
          Disabled = false,
        },
        new()
        {
          SkillId = NodeJsSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Uso de Node.js para crear aplicaciones web, incluyendo la creación de rutas, la gestión de peticiones, y la comunicación con bases de datos.",
          Disabled = false,
        },
        new()
        {
          SkillId = SpringBootSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Comprende la estructura de un proyecto Spring Boot, incluyendo controladores, servicios, y repositorios.",
          Disabled = false,
        },
        new()
        {
          SkillId = SpringBootSkillId,
          SubSkillId = Guid.NewGuid(),
          Name =
            "Uso de Spring Boot para crear aplicaciones web, incluyendo la creación de controladores, la gestión de servicios, y la comunicación con bases de datos.",
          Disabled = false,
        },
      };
      modelBuilder.Entity<SubSkillModel>().HasData(subskills);
    }
  }
}
