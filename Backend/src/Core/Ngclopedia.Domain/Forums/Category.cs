using System.ComponentModel;

namespace Ngclopedia.Domain.Forums;

public enum Category
{
    [Description("Includes Telecommunications, Broadcast Media and Internet, etc.")]
    Communications = 10,

    [Description("Includes GDP, Inflation, Credit Ratings, Agriculture, Industries, Labor Force, Unemployment, " +
                 "Population, Public Income, Budget, Debt, Taxes, Revenues, Account Balance, Exports, Imports," +
                 "Foreign Reserves, Exchange Rate etc.")]
    Economy = 20,

    [Description("Includes Electricity, Coal, Petroleum, Natural Gas, CO2 Emissions, Energy Consumption, etc.")]
    Energy = 30,

    [Description("Includes Current Issues, International Agreement, Air Pollutants, Climate, Land Use, Urbanization," +
                 "Revenue, Major Infectious Diseases, Food Insecurity, Waste and Recycling, Major Water Bodies, etc.")]
    Environment = 40,

    [Description(
        "Includes Location, Geographic Coordinates, Map References, Area, Land Boundaries, Coastline, Maritime" +
        "Claims, Climate, Terrain, Elevation, Natural Resources, Land Use, Irrigated Land, Major Water Bodies," +
        "Population Distribution, Natural Hazards, Map Description")]
    Geography = 50,

    [Description("Includes Name, Government Type, Capital/Main Area, Administrative Divisions, Independence, " +
                 "Constitution, Legal System, International Organization Participation, Citizenship, Suffrage," +
                 "Executive Branch, Legislative Branch, Judicial Branch, Political Parties and Leaders, Diplomatic " +
                 "Representations, Flag Description, National Symbols, National Heritage, etc.")]
    Government = 60,

    [Description("Includes Population, Nationality, Ethnic Groups, Languages, Religions, Demographic Profile," +
                 "Age Structure, Dependency Ratios, Median Age, Population Growth Rate, Birth Rate, Death Rate," +
                 "Net Migration, Population Distribution, Urbanization, Sex Ratio, Mortality Rate, Life Expectancy," +
                 "Fertility Rate, Health Expenditures, Physicians Density, Sanitation, Major Infectious Diseases, " +
                 "Obesity, Alcohol & Drug Consumption, Tobacco, Marriage And Family, Education, Literacy" +
                 "Unemployment, Culture, Food, Arts And Entertainment, etc.")]
    PeopleAndSociety = 70,

    [Description(
        "Includes Military And Security Forces, Military And Security Forces Expenditures, Miltary And Security" +
        "Service Personnel Strength, Military And Security Forces Equipment Inventories And Acqisitions," +
        "Military And Security Forces Service Age And Obligation, Miltary And Security Forces Deploymeny," +
        "Maritime Threats, Terrorism And Banditry")]
    MilitaryAndSecurity = 80,

    [Description("Includes National Air Transport System, Civil Aircraft, Airports, Heliports, Pipelines, Railways," +
                 "Roadways, Waterways, Merchant Marine, Ports And Terminals, etc.")]
    Transportation = 90,

    [Description("Includes Disputes, Refugees And Internally Displaced Persons, Human Trafficking, Illicit Drugs," +
                 "")]
    TransnationalIssues = 15
}