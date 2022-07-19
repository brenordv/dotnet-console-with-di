# .net6 Console Application with Dependency Injection
This is a simple Console application to demonstrate a way to use Dependency Injection with it.  
I also made a simple implementation of the Monad pattern.

## Cli Methods
Although the cli application is not interactable, I left a handful of methods there to try out my implementation.
The methods used are explained bellow.

### ListHouses
This will fetch and list all the Houses in the API
Sample:
```shell
House { Id = 0367baf3-1cb6-4baf-bede-48e17e1cd005, Name = Gryffindor, HouseColors = Scarlet and gold, Founder = Godric Gryffindor, Animal = Lion, Element = Fire, Ghost = Nearly-Headless Nick, CommonRoom = Gryffindor Tower, Heads = S
ystem.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.HouseHead], Traits = System.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.HouseTrait] }
House { Id = 805fd37a-65ae-4fe5-b336-d767b8b7c73a, Name = Ravenclaw, HouseColors = Blue and bronze, Founder = Rowena Ravenclaw, Animal = Eagle, Element = Air, Ghost = Grey Lady, CommonRoom = Ravenclaw Tower, Heads = System.Collectio
ns.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.HouseHead], Traits = System.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.HouseTrait] }
House { Id = 85af6295-fd01-4170-a10b-963dd51dce14, Name = Hufflepuff, HouseColors = Yellow and black, Founder = Helga Hufflepuff, Animal = Badger, Element = Earth, Ghost = Fat Friar, CommonRoom = Hufflepuff Basement, Heads = System.
Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.HouseHead], Traits = System.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.HouseTrait] }
House { Id = a9704c47-f92e-40a4-8771-ed1899c9b9c1, Name = Slytherin, HouseColors = Green and silver, Founder = Salazar Slytherin, Animal = Serpent, Element = Water, Ghost = Bloody Baron, CommonRoom = Slytherin Dungeon, Heads = Syste
m.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.HouseHead], Traits = System.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.HouseTrait] }
```

### ListGenericHouses
Same as before, but treats the Houses as a `Dictionary<string, object>` instead of a `Record`.
Sample: 
```shell
--------------------------------------------------
id: 805fd37a-65ae-4fe5-b336-d767b8b7c73a
name: Ravenclaw
houseColours: Blue and bronze
founder: Rowena Ravenclaw
animal: Eagle
element: Air
ghost: Grey Lady
commonRoom: Ravenclaw Tower
heads:
-- {
  "id": "102ac5fc-db71-4055-8250-bc238cffb3d9",
  "firstName": "Filius",
  "lastName": "Flitwick"
}
-- {
  "id": "57c04cf4-f3dd-46d6-a78f-84c30fb42533",
  "firstName": "Rowena",
  "lastName": "Ravenclaw"
}
heads: System.Collections.Generic.List`1[System.Object]
traits:
-- {
  "id": "08a54d21-6137-4eda-9c32-004706650b44",
  "name": "Learning"
}
-- {
  "id": "5056effc-b92b-4f86-96fd-978b26a849da",
  "name": "Acceptance"
}
-- {
  "id": "78db6224-33d1-490d-a553-9bbbedb3282a",
  "name": "Inteligence"
}
-- {
  "id": "ab88a4fb-1c4d-4e14-88bf-7f55dfabb75a",
  "name": "Wisdom"
}
-- {
  "id": "e43d0b2f-dcfe-4a5f-b3ab-d39679bbfbe3",
  "name": "Wit"
}
-- {
  "id": "ffc55017-c03f-490a-9c48-2f38af6e2f0a",
  "name": "Creativity"
}
traits: System.Collections.Generic.List`1[System.Object]
```

### ListWizards
Lists all Wizards in the API
Sample: 
```shell
Wizard { Id = 03ca5597-ded5-419c-9620-31eb44a04457, FirstName = , LastName = Mrs Skower, Elixirs = System.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.Elixir] }
Wizard { Id = 118e7366-1c65-4275-8121-8f6c553e5783, FirstName = Fred, LastName = Weasley, Elixirs = System.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.Elixir] }
Wizard { Id = 30bd3b76-57f0-4a25-be3b-41bbeccae927, FirstName = Fleamont, LastName = Potter, Elixirs = System.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.Elixir] }
Wizard { Id = 46e84861-0489-4239-b940-dd794aa631a2, FirstName = , LastName = Dr Ubbly, Elixirs = System.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.Elixir] }
Wizard { Id = 599265f8-029a-45ea-9a66-29715f34aef0, FirstName = Glover, LastName = Hipworth, Elixirs = System.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.Elixir] }
Wizard { Id = 913407b0-9c11-4002-a080-6874436c3a93, FirstName = Nicolas, LastName = Flamel, Elixirs = System.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.Elixir] }

```

### ListWizardById
List a single Wizard (fetching it by id)
Sample:
```shell
Wizard { Id = f86280b1-faa6-44fd-b8a9-f7a4556f8d20, FirstName = Zygmunt, LastName = Budge, Elixirs = System.Collections.Generic.List`1[Raccoon.Ninja.Console.App.With.Di.Core.Models.Elixir] }
```

### Note
I deliberately left out a way to "pretty print" lists. I'll come back to that later... maybe.

## Data source
Instead of creating a Database, I used an API themed after the Harry Potter universe. It's a great API with a well documented swagger.
- API Github: https://github.com/MossPiglets/WizardWorldAPI
- API Swagger: https://wizard-world-api.herokuapp.com/swagger/index.html
