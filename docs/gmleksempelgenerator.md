# GML-eksempelgenerator

# Beskrivelse av funksjonalitet:

GML-eksempelgeneratoren er en webapplikasjon som tilbyr brukere å generere et GML-eksempel ut i fra et XML-skjema (XSD).

Brukeren kan laste opp en XSD-fil fra sin lokale pc, eller angi en URL til en XSD-fil. Applikasjonen genererer deretter et GML-eksempel som brukeren kan laste ned til sin lokale pc. 


## Teknisk

**URL:**

-**Dev**: http://generator.dev.geonorge.no/

-**Test**: http://generator.test.geonorge.no/

-**Prod**: https://gmlgenerator.geonorge.no/

**Kildekode**: https://arkitektum.visualstudio.com/_git/Kartverket.GmlSampleGenerator 

**Oversikt kildekode:**

Applikasjonen er utviklet med C# og .NET framework.
- **/Kartverket.Generators** Klassebibliotek med kjernefunksjonalitet for å generere eksempeldata
- **/Kartverket.Generators.Tests** Tester av klassebiblioteket
- **/Kartverket.GmlSampleGenerator** Web applikasjon: ASP.NET MVC 5

Applikasjonen har en veldig enkel arkitektur med en webapplikasjon som kaller opp et klassebibliotek. Dette biblioteket inneholder de klassene som behøves for å generere eksempeldata. Ved å splitte kjernefunksjonaliteten ut i et eget klassebibliotek kan dette tilgjengeliggjøres for andre applikasjoner på en enkel måte. 

Webapplikasjonen tar seg av innlesing av XSD-fila fra brukeren og sender denne til klassebiblioteket, det genereres et GML-eksempel som returneres til webapplikasjonen og deretter til brukeren som en nedlastbar fil.
