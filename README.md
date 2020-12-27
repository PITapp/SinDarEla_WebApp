# Hauptfarbe orange: F1903C

# Farbe Icon Hintergrund orange: DE8823

# Whitesmoke: f5f5f5

# Quill Editor einbinden
https://www.primefaces.org/primeng/showcase/#/editor

- npm install quill --save

# push an existing repository from the command line
git remote add origin https://github.com/PITapp/SinDarEla_WebApp.git

# Berichte erzeugen:
https://forum.radzen.com/t/creating-reports/5844
https://github.com/FastReports/FastReport
https://www.stimulsoft.com/de

# Löschen node_modules und neu installieren
> cd cliend 
> rm -r node_modules
> npm install



### Ab hier alte Sachen, die nicht funktionieren
##
#

# Die Tabelle AspNetUsers mit weiteren Datenbankfeldern erweitern
===============================================================

https://www.radzen.com/documentation/crm-security/

Add a new file server\Models\ApplicationUser.Custom.cs with the following content.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SinDarEla.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public int BaseID {get; set;}
        public string BenutzerName {get; set;}
    }
}

The ApplicationUser class represents a record from the AspNetUsers table and by adding those three properties we extend it.

Add a new file server\Data\DbSinDarElaContext.Custom.cs with the following content.

using Microsoft.EntityFrameworkCore;
using SinDarEla.Models;

namespace SinDarEla.Data
{
    public partial class DbSinDarElaContext
    {
        partial void OnModelBuilding(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers");
        }
    }
}

Open a command prompt window and go to the server directory of the CRM application.

Run the following command (it will take some time to complete):
dotnet ef migrations add CreateIdentitySchema2 -c ApplicationIdentityDbContext -v

### Was tun bei der Meldung:
Your startup project 'server' doesn't reference Microsoft.EntityFrameworkCore.Design. This package is required for the Entity Framework Core Tools to work. Ensure your startup project is correct, install the package, and try again.

    1) dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.1
