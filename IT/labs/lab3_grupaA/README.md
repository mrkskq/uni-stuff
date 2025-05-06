Na pochetok Build na proektot

So sekoja izmena (ili na pogolema izmena nakraj) vo Tools -> NuGet Packege Manager -> Package Manager Console 

> Enable-Migrations (samo na pocetok)

> Add-Migration (i nekoe ime na migracijata (pr. Initial, blabla....)) <br>
> Update-Database

Prvo napishi gi tie trite vo Models
Posle dodaj gi trite Controllers (avtomatski so tretiot controller sve ke se izgenerirat to so Entity Framework i odberi za koj model i vo Data context class: ApplicationDbContext)
Vo controlerot za Doctor imat izmena nakraj

i posle vo Views imat nekoj izmeni vo nekoja linija (od to sho avtomatski ke se izgeneriret preku kontrolerite) - obelezani se so komentari <br> //----------->

i uste izmena vo to Layout za preku link da mojt da se pristapit 😙
