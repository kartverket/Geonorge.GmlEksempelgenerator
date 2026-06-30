# Geonorge.GmlEEksempelgenerator

GML-eksempelgeneratoren er en webapplikasjon som tilbyr brukere å generere et GML-eksempel ut i fra et XML-skjema (XSD).

Brukeren kan laste opp en XSD-fil fra sin lokale pc, eller angi en URL til en XSD-fil. Applikasjonen genererer deretter et GML-eksempel som brukeren kan laste ned til sin lokale pc. ren generering av produktark i pdf format for datasett. 

## Kom i gang

### Forutsetninger

- .net framework 4.7.2

### Oppsett

1. Klon repoet:
   ```bash
   git clone git@github.com:kartverket/Geonorge.GmlEksempelgenerator.git
   cd Geonorge.GmlEksempelgenerator
   ```

2. Installer avhengigheter:
   ```bash
   yarn install
   ```

3. Konfigurer miljøvariabler — kopier `settings.default.config` til `settings.config` og fyll inn riktige verdier: