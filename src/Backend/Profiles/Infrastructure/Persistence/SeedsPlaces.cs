using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence
{
  public class SeedsPlaces
  {
    private static Guid VenezuelaId = Guid.NewGuid();
    private static Guid PanamaId = Guid.NewGuid();
    private static Guid CostaRicaId = Guid.NewGuid();
    private static Guid NicaraguaId = Guid.NewGuid();
    private static Guid HondurasId = Guid.NewGuid();
    private static Guid GuatemalaId = Guid.NewGuid();
    private static Guid ElSalvadorId = Guid.NewGuid();
    private static Guid BelizeId = Guid.NewGuid();
    private static Guid MexicoId = Guid.NewGuid();
    private static Guid PeruId = Guid.NewGuid();
    private static Guid ChileId = Guid.NewGuid();
    private static Guid ArgentinaId = Guid.NewGuid();
    private static Guid BrazilId = Guid.NewGuid();
    private static Guid ParaguayId = Guid.NewGuid();
    private static Guid UruguayId = Guid.NewGuid();
    private static Guid BoliviaId = Guid.NewGuid();

    private static Guid EcuadorId = Guid.NewGuid();
    private static Guid AzuayId = Guid.NewGuid();
    private static Guid BolivarEId = Guid.NewGuid();
    private static Guid CanarId = Guid.NewGuid();
    private static Guid CarchiId = Guid.NewGuid();
    private static Guid ChimborazoId = Guid.NewGuid();
    private static Guid CotopaxiId = Guid.NewGuid();
    private static Guid ElOroId = Guid.NewGuid();
    private static Guid EsmeraldasId = Guid.NewGuid();
    private static Guid GalapagosId = Guid.NewGuid();
    private static Guid GuayasId = Guid.NewGuid();
    private static Guid ImbaburaId = Guid.NewGuid();
    private static Guid LojaId = Guid.NewGuid();
    private static Guid ManabiId = Guid.NewGuid();
    private static Guid MoronaSantiagoId = Guid.NewGuid();
    private static Guid NapoId = Guid.NewGuid();

    private static Guid ColombiaId = Guid.NewGuid();
    private static Guid AmazonasId = Guid.NewGuid();
    private static Guid AntioquiaId = Guid.NewGuid();
    private static Guid AraucaId = Guid.NewGuid();
    private static Guid AtlanticoId = Guid.NewGuid();
    private static Guid BolivarId = Guid.NewGuid();
    private static Guid BoyacaId = Guid.NewGuid();
    private static Guid CaldasId = Guid.NewGuid();
    private static Guid CaquetaId = Guid.NewGuid();
    private static Guid CasanareId = Guid.NewGuid();
    private static Guid CaucaId = Guid.NewGuid();
    private static Guid CesarId = Guid.NewGuid();
    private static Guid ChocoId = Guid.NewGuid();
    private static Guid CordobaId = Guid.NewGuid();
    private static Guid CundinamarcaId = Guid.NewGuid();
    private static Guid GuainiaId = Guid.NewGuid();
    private static Guid GuaviareId = Guid.NewGuid();
    private static Guid HuilaId = Guid.NewGuid();
    private static Guid LaGuajiraId = Guid.NewGuid();
    private static Guid MagdalenaId = Guid.NewGuid();
    private static Guid MetaId = Guid.NewGuid();
    private static Guid NarinoId = Guid.NewGuid();
    private static Guid NorteDeSantanderId = Guid.NewGuid();
    private static Guid PutumayoId = Guid.NewGuid();
    private static Guid QuindioId = Guid.NewGuid();
    private static Guid RisaraldaId = Guid.NewGuid();
    private static Guid SanAndresYProvidenciaId = Guid.NewGuid();
    private static Guid SantanderId = Guid.NewGuid();
    private static Guid SucreId = Guid.NewGuid();
    private static Guid TolimaId = Guid.NewGuid();
    private static Guid ValleDelCaucaId = Guid.NewGuid();
    private static Guid VaupesId = Guid.NewGuid();
    private static Guid VichadaId = Guid.NewGuid();

    public static void SeedCountries(ModelBuilder modelBuilder)
    {
      var countries = new List<CountryModel>
      {
        new()
        {
          CountryId = ColombiaId,
          Name = "Colombia",
          Disabled = false,
        },
        new()
        {
          CountryId = EcuadorId,
          Name = "Ecuador",
          Disabled = false,
        },
        new()
        {
          CountryId = VenezuelaId,
          Name = "Venezuela",
          Disabled = false,
        },
        new()
        {
          CountryId = PanamaId,
          Name = "Panamá",
          Disabled = false,
        },
        new()
        {
          CountryId = CostaRicaId,
          Name = "Costa Rica",
          Disabled = false,
        },
        new()
        {
          CountryId = NicaraguaId,
          Name = "Nicaragua",
          Disabled = false,
        },
        new()
        {
          CountryId = HondurasId,
          Name = "Honduras",
          Disabled = false,
        },
        new()
        {
          CountryId = GuatemalaId,
          Name = "Guatemala",
          Disabled = false,
        },
        new()
        {
          CountryId = ElSalvadorId,
          Name = "El Salvador",
          Disabled = false,
        },
        new()
        {
          CountryId = BelizeId,
          Name = "Belize",
          Disabled = false,
        },
        new()
        {
          CountryId = MexicoId,
          Name = "México",
          Disabled = false,
        },
        new()
        {
          CountryId = PeruId,
          Name = "Perú",
          Disabled = false,
        },
        new()
        {
          CountryId = ChileId,
          Name = "Chile",
          Disabled = false,
        },
        new()
        {
          CountryId = ArgentinaId,
          Name = "Argentina",
          Disabled = false,
        },
        new()
        {
          CountryId = BrazilId,
          Name = "Brasil",
          Disabled = false,
        },
        new()
        {
          CountryId = ParaguayId,
          Name = "Paraguay",
          Disabled = false,
        },
        new()
        {
          CountryId = UruguayId,
          Name = "Uruguay",
          Disabled = false,
        },
        new()
        {
          CountryId = BoliviaId,
          Name = "Bolivia",
          Disabled = false,
        },
      };

      modelBuilder.Entity<CountryModel>().HasData(countries);
    }

    public static void SeedProvinces(ModelBuilder modelBuilder)
    {
      var provinces = new List<ProvinceModel>
      {
        new()
        {
          ProvinceId = AmazonasId,
          Name = "Amazonas",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = AntioquiaId,
          Name = "Antioquia",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = AraucaId,
          Name = "Arauca",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = AtlanticoId,
          Name = "Atlántico",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = BolivarId,
          Name = "Bolívar",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = BoyacaId,
          Name = "Boyacá",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = CaldasId,
          Name = "Caldas",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = CaquetaId,
          Name = "Caquetá",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = CasanareId,
          Name = "Casanare",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = CaucaId,
          Name = "Cauca",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = CesarId,
          Name = "Cesar",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = ChocoId,
          Name = "Chocó",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = CordobaId,
          Name = "Córdoba",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = CundinamarcaId,
          Name = "Cundinamarca",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = GuainiaId,
          Name = "Guainía",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = GuaviareId,
          Name = "Guaviare",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = HuilaId,
          Name = "Huila",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = LaGuajiraId,
          Name = "La Guajira",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = MagdalenaId,
          Name = "Magdalena",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = MetaId,
          Name = "Meta",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = NarinoId,
          Name = "Nariño",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = NorteDeSantanderId,
          Name = "Norte de Santander",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = PutumayoId,
          Name = "Putumayo",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = QuindioId,
          Name = "Quindío",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = RisaraldaId,
          Name = "Risaralda",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = SanAndresYProvidenciaId,
          Name = "San Andrés y Providencia",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = SantanderId,
          Name = "Santander",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = SucreId,
          Name = "Sucre",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = TolimaId,
          Name = "Tolima",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = ValleDelCaucaId,
          Name = "Valle del Cauca",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = VaupesId,
          Name = "Vaupés",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = VichadaId,
          Name = "Vichada",
          CountryId = ColombiaId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = AzuayId,
          Name = "Azuay",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = BolivarEId,
          Name = "Bolívar",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = CanarId,
          Name = "Cañar",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = CarchiId,
          Name = "Carchi",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = ChimborazoId,
          Name = "Chimborazo",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = CotopaxiId,
          Name = "Cotopaxi",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = ElOroId,
          Name = "El Oro",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = EsmeraldasId,
          Name = "Esmeraldas",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = GalapagosId,
          Name = "Galápagos",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = GuayasId,
          Name = "Guayas",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = ImbaburaId,
          Name = "Imbabura",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = LojaId,
          Name = "Loja",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = ManabiId,
          Name = "Manabí",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = MoronaSantiagoId,
          Name = "Morona Santiago",
          CountryId = EcuadorId,
          Disabled = false,
        },
        new()
        {
          ProvinceId = NapoId,
          Name = "Napo",
          CountryId = EcuadorId,
          Disabled = false,
        },
      };
      modelBuilder.Entity<ProvinceModel>().HasData(provinces);
    }

    public static void SeedCities(ModelBuilder modelBuilder)
    {
      var cities = new List<CityModel>()
      {
        // Amazonas
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Leticia",
          ProvinceId = AmazonasId,
          Disabled = false
        },
        // Antioquia
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Medellín",
          ProvinceId = AntioquiaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Apartadó",
          ProvinceId = AntioquiaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Turbo",
          ProvinceId = AntioquiaId,
          Disabled = false
        },
        // Arauca
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Arauca",
          ProvinceId = AraucaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Saravena",
          ProvinceId = AraucaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Fortul",
          ProvinceId = AraucaId,
          Disabled = false
        },
        // Atlántico
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Barranquilla",
          ProvinceId = AtlanticoId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Soledad",
          ProvinceId = AtlanticoId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Puerto Colombia",
          ProvinceId = AtlanticoId,
          Disabled = false
        },
        // Bolívar
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Cartagena de Indias",
          ProvinceId = BolivarId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Magangué",
          ProvinceId = BolivarId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Cartagena del Chairá",
          ProvinceId = BolivarId,
          Disabled = false
        },
        // Boyacá
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Tunja",
          ProvinceId = BoyacaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Sogamoso",
          ProvinceId = BoyacaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Duitama",
          ProvinceId = BoyacaId,
          Disabled = false
        },
        // Caldas
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Manizales",
          ProvinceId = CaldasId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Pereira",
          ProvinceId = CaldasId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Chinchiná",
          ProvinceId = CaldasId,
          Disabled = false
        },
        // Caquetá
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Florencia",
          ProvinceId = CaquetaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Cartagena del Chairá",
          ProvinceId = CaquetaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Morelia",
          ProvinceId = CaquetaId,
          Disabled = false
        },
        // Casanare
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Yopal",
          ProvinceId = CasanareId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Aguazul",
          ProvinceId = CasanareId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Tauramena",
          ProvinceId = CasanareId,
          Disabled = false
        },
        // Cauca
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Popayán",
          ProvinceId = CaucaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Silvia",
          ProvinceId = CaucaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Santander de Quilichao",
          ProvinceId = CaucaId,
          Disabled = false
        },
        // Cesar
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Valledupar",
          ProvinceId = CesarId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Aguachica",
          ProvinceId = CesarId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "La Paz",
          ProvinceId = CesarId,
          Disabled = false
        },
        // Chocó
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Quibdó",
          ProvinceId = ChocoId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Istmina",
          ProvinceId = ChocoId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Novita",
          ProvinceId = ChocoId,
          Disabled = false
        },
        // Córdoba
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Montería",
          ProvinceId = CordobaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Cereté",
          ProvinceId = CordobaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Lorica",
          ProvinceId = CordobaId,
          Disabled = false
        },
        // Cundinamarca
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Bogotá",
          ProvinceId = CundinamarcaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Soacha",
          ProvinceId = CundinamarcaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Zipaquirá",
          ProvinceId = CundinamarcaId,
          Disabled = false
        },
        // Guainía
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Inírida",
          ProvinceId = GuainiaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Puerto Inírida",
          ProvinceId = GuainiaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Memarí",
          ProvinceId = GuainiaId,
          Disabled = false
        },
        // Guaviare
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "San José del Guaviare",
          ProvinceId = GuaviareId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Calamar",
          ProvinceId = GuaviareId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "El Retén",
          ProvinceId = GuaviareId,
          Disabled = false
        },
        // Huila
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Neiva",
          ProvinceId = HuilaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Garzón",
          ProvinceId = HuilaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Pitalito",
          ProvinceId = HuilaId,
          Disabled = false
        },
        // La Guajira
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Riohacha",
          ProvinceId = LaGuajiraId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Maicao",
          ProvinceId = LaGuajiraId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Uribia",
          ProvinceId = LaGuajiraId,
          Disabled = false
        },
        // Magdalena
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Santa Marta",
          ProvinceId = MagdalenaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Aracataca",
          ProvinceId = MagdalenaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Ciénaga",
          ProvinceId = MagdalenaId,
          Disabled = false
        },
        // Meta
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Villavicencio",
          ProvinceId = MetaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Acacias",
          ProvinceId = MetaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Granada",
          ProvinceId = MetaId,
          Disabled = false
        },
        // Nariño
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "San Juan de Pasto",
          ProvinceId = NarinoId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Tumaco",
          ProvinceId = NarinoId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Ipiales",
          ProvinceId = NarinoId,
          Disabled = false
        },
        // Norte de Santander
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Cúcuta",
          ProvinceId = NorteDeSantanderId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Ocaña",
          ProvinceId = NorteDeSantanderId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Pamplona",
          ProvinceId = NorteDeSantanderId,
          Disabled = false
        },
        // Putumayo
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Mocoa",
          ProvinceId = PutumayoId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Puerto Asís",
          ProvinceId = PutumayoId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Orito",
          ProvinceId = PutumayoId,
          Disabled = false
        },
        // Quindío
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Armenia",
          ProvinceId = QuindioId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Calarcá",
          ProvinceId = QuindioId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "La Tebaida",
          ProvinceId = QuindioId,
          Disabled = false
        },
        // Risaralda
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Pereira",
          ProvinceId = RisaraldaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Dosquebradas",
          ProvinceId = RisaraldaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Santa Rosa de Cabal",
          ProvinceId = RisaraldaId,
          Disabled = false
        },
        // San Andrés y Providencia
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "San Andrés",
          ProvinceId = SanAndresYProvidenciaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Providencia",
          ProvinceId = SanAndresYProvidenciaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Santa Catalina",
          ProvinceId = SanAndresYProvidenciaId,
          Disabled = false
        },
        // Santander
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Bucaramanga",
          ProvinceId = SantanderId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Barrancabermeja",
          ProvinceId = SantanderId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Piedecuesta",
          ProvinceId = SantanderId,
          Disabled = false
        },
        // Sucre
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Sincelejo",
          ProvinceId = SucreId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Corozal",
          ProvinceId = SucreId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Montería",
          ProvinceId = SucreId,
          Disabled = false
        },
        // Tolima
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Ibagué",
          ProvinceId = TolimaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Honda",
          ProvinceId = TolimaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Armero Guayabal",
          ProvinceId = TolimaId,
          Disabled = false
        },
        // Valle del Cauca
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Cali",
          ProvinceId = ValleDelCaucaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Palmira",
          ProvinceId = ValleDelCaucaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Buenaventura",
          ProvinceId = ValleDelCaucaId,
          Disabled = false
        },
        // Vaupés
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Mitú",
          ProvinceId = VaupesId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Yavaraté",
          ProvinceId = VaupesId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Santa Rosalía",
          ProvinceId = VaupesId,
          Disabled = false
        },
        // Vichada
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Puerto Carreño",
          ProvinceId = VichadaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "La Primavera",
          ProvinceId = VichadaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Santa Helena",
          ProvinceId = VichadaId,
          Disabled = false
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Cuenca",
          ProvinceId = AzuayId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Girón",
          ProvinceId = AzuayId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Guaranda",
          ProvinceId = BolivarEId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "San Miguel de Bolívar",
          ProvinceId = BolivarEId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Azogues",
          ProvinceId = CanarId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "El Tambo",
          ProvinceId = CanarId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Tulcán",
          ProvinceId = CarchiId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "El Guabo",
          ProvinceId = CarchiId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Riobamba",
          ProvinceId = ChimborazoId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Alausí",
          ProvinceId = ChimborazoId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Latacunga",
          ProvinceId = CotopaxiId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Salcedo",
          ProvinceId = CotopaxiId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Machala",
          ProvinceId = ElOroId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Santa Rosa",
          ProvinceId = ElOroId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Esmeraldas",
          ProvinceId = EsmeraldasId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Atacames",
          ProvinceId = EsmeraldasId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Puerto Baquerizo Moreno",
          ProvinceId = GalapagosId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "San Cristóbal",
          ProvinceId = GalapagosId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Guayaquil",
          ProvinceId = GuayasId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Durán",
          ProvinceId = GuayasId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Ibarra",
          ProvinceId = ImbaburaId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Otavalo",
          ProvinceId = ImbaburaId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Loja",
          ProvinceId = LojaId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Saraguro",
          ProvinceId = LojaId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Portoviejo",
          ProvinceId = ManabiId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Manta",
          ProvinceId = ManabiId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Chone",
          ProvinceId = ManabiId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Macas",
          ProvinceId = MoronaSantiagoId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Gualaquiza",
          ProvinceId = MoronaSantiagoId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Tena",
          ProvinceId = NapoId,
          Disabled = false,
        },
        new()
        {
          CityId = Guid.NewGuid(),
          Name = "Archidona",
          ProvinceId = NapoId,
          Disabled = false,
        },
      };
      modelBuilder.Entity<CityModel>().HasData(cities);
    }
  }
}
