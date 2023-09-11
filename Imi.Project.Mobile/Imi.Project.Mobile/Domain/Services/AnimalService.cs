using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class AnimalService : IAnimalRepository
    {

        private List<Animal> animals = new List<Animal>
        {
            new Animal
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000001"),
                NameFamily = "Osphronemidae",
                NameDutch = "Betta Splendens",
                ImageUrl = new Uri("https://cdn.webshopapp.com/shops/277529/files/258589718/image.jpg"),
                TempMin = 20,
                TempMax = 28,
                PhMin = 7,
                PhMax = 8,
                GhMin = 8,
                GhMax = 12,
                Breedings = new List<Breeding>
                {
                    new Breeding
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Schuimnestbouwer"
                    }
                },
                Continents = new List<Continent>
                {
                    new Continent
                    {
                        Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                        Name = "Azië"
                    }
                },
                Diets = new List<Diet>
                {
                    new Diet()
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                        Name = "Omnivoor"
                    }
                },
                Kinds = new List<Kind>
                {
                    new Kind
                    {
                        Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                        Name = "Vis"
                    }
                },
                Socials = new List<Social>
                {
                    new Social
                    {
                        Id = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                        Name = "Solitair"
                    }
                }
            },
            new Animal
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000002"),
                NameFamily = "Loricariidae",
                NameDutch = "Ancistruss",
                ImageUrl = new Uri(
                    "https://cdn.myonlinestore.eu/93c794e2-6be1-11e9-a722-44a8421b9960/image/cache/full/c2168c65e550dd3c38fcb81c7173b0004588ee52.jpg"),
                TempMin = 23,
                TempMax = 26,
                PhMin = 6,
                PhMax = 8,
                GhMin = 5,
                GhMax = 15,
                Breedings = new List<Breeding>
                {
                    new Breeding
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Holenbroeder"
                    }
                },
                Continents = new List<Continent>
                {
                    new Continent
                    {
                        Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                        Name = "Zuid-Amerika"
                    }
                },
                Diets = new List<Diet>
                {
                    new Diet()
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                        Name = "Omnivoor"
                    }
                },
                Kinds = new List<Kind>
                {
                    new Kind
                    {
                        Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                        Name = "Vis"
                    }
                },
                Socials = new List<Social>
                {
                    new Social
                    {
                        Id = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                        Name = "Koppel"
                    }
                }
            },

            new Animal
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000003"),
                NameFamily = "Callichthyidae",
                NameDutch = "Bandiet Corydoras",
                ImageUrl = new Uri("https://www.tropco.co.uk/images/Bandit%20Cory.jpg"),
                TempMin = 21,
                TempMax = 24,
                PhMin = 6,
                PhMax = 7,
                GhMin = 5,
                GhMax = 12,
                Breedings = new List<Breeding>
                {
                    new Breeding
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Substraatbroeder"
                    }
                },
                Continents = new List<Continent>
                {
                    new Continent
                    {
                        Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                        Name = "Zuid-Amerika"
                    }
                },
                Diets = new List<Diet>
                {
                    new Diet()
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                        Name = "Omnivoor"
                    }
                },
                Kinds = new List<Kind>
                {
                    new Kind
                    {
                        Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                        Name = "Vis"
                    }
                },
                Socials = new List<Social>
                {
                    new Social
                    {
                        Id = Guid.Parse("40000000-0000-0000-0000-000000000003"),
                        Name = "School"
                    }
                }
            },

            new Animal
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000004"),
                NameFamily = "Neritidae",
                NameDutch = "Rode Neritina Slak",
                ImageUrl = new Uri("https://aquainfo.nl/wp-content/uploads/2018/08/Vittina-waigiensis6.jpg"),
                TempMin = 20,
                TempMax = 30,
                PhMin = 7,
                PhMax = 9,
                GhMin = 10,
                GhMax = 30,
                Breedings = new List<Breeding>
                {
                    new Breeding
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Vrijlegger"
                    }
                },
                Continents = new List<Continent>
                {
                    new Continent
                    {
                        Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                        Name = "Zuid-Amerika"
                    }
                },
                Diets = new List<Diet>
                {
                    new Diet()
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                        Name = "Omnivoor"
                    }
                },
                Kinds = new List<Kind>
                {
                    new Kind
                    {
                        Id = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                        Name = "Slak"
                    }
                },
                Socials = new List<Social>
                {
                    new Social
                    {
                        Id = Guid.Parse("40000000-0000-0000-0000-000000000004"),
                        Name = "Groep"
                    }
                }
            },

            new Animal
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000005"),
                NameFamily = "Atyidae",
                NameDutch = "Afrikaanse Waaierhandgarnaal",
                ImageUrl = new Uri(
                    "https://aquainfo.nl/wp-content/uploads/2019/02/Atya-gabonensis-Blauwe-Waaierhandgarnaal3-1.jpg"),
                TempMin = 20,
                TempMax = 30,
                PhMin = 6,
                PhMax = 8,
                GhMin = 8,
                GhMax = 12,
                Breedings = new List<Breeding>
                {
                    new Breeding
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "Bijhouden"
                    }
                },
                Continents = new List<Continent>
                {
                    new Continent
                    {
                        Id = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                        Name = "Afrika"
                    }
                },
                Diets = new List<Diet>
                {
                    new Diet()
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                        Name = "Omnivoor"
                    }
                },
                Kinds = new List<Kind>
                {
                    new Kind
                    {
                        Id = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                        Name = "Garnaal"
                    }
                },
                Socials = new List<Social>
                {
                    new Social
                    {
                        Id = Guid.Parse("40000000-0000-0000-0000-000000000004"),
                        Name = "Groep"
                    }
                }
            },

            new Animal
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000006"),
                NameFamily = "Atyidae",
                NameDutch = "Kardinaalgarnaal",
                ImageUrl = new Uri(
                    "https://aquainfo.nl/wp-content/uploads/2012/05/Caridina-dennerli-Caridina-dennerli-Kardinaalgarnaal.jpg"),
                TempMin = 20,
                TempMax = 30,
                PhMin = 6,
                PhMax = 8,
                GhMin = 8,
                GhMax = 12,
                Breedings = new List<Breeding>
                {
                    new Breeding
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "Bijhouden"
                    }
                },
                Continents = new List<Continent>
                {
                    new Continent
                    {
                        Id = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                        Name = "Afrika"
                    }
                },
                Diets = new List<Diet>
                {
                    new Diet()
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                        Name = "Omnivoor"
                    }
                },
                Kinds = new List<Kind>
                {
                    new Kind
                    {
                        Id = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                        Name = "Garnaal"
                    }
                },
                Socials = new List<Social>
                {
                    new Social
                    {
                        Id = Guid.Parse("40000000-0000-0000-0000-000000000004"),
                        Name = "Groep"
                    }
                }
            },

            new Animal
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000007"),
                NameFamily = "Cambaridae",
                NameDutch = "Oranje Dwergrivierkreeft – CPO Kreeft",
                ImageUrl = new Uri(
                    "https://cdn.myonlinestore.eu/93c794e2-6be1-11e9-a722-44a8421b9960/image/cache/full/0730e24b9cf5aff6343b82caa9413d3a2ed8ab9b.jpg"),
                TempMin = 15,
                TempMax = 25,
                PhMin = 6,
                PhMax = 8,
                GhMin = 5,
                GhMax = 12,
                Breedings = new List<Breeding>
                {
                    new Breeding
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "Bijhouden"
                    }
                },
                Continents = new List<Continent>
                {
                    new Continent
                    {
                        Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                        Name = "Afrika"
                    }
                },
                Diets = new List<Diet>
                {
                    new Diet()
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                        Name = "Omnivoor"
                    }
                },
                Kinds = new List<Kind>
                {
                    new Kind
                    {
                        Id = Guid.Parse("20000000-0000-0000-0000-000000000004"),
                        Name = "Kreeft"
                    }
                },
                Socials = new List<Social>
                {
                    new Social
                    {
                        Id = Guid.Parse("40000000-0000-0000-0000-000000000004"),
                        Name = "Groep"
                    }
                }
            },

            new Animal
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000008"),
                NameFamily = "Cambaridae",
                NameDutch = "Rode Amerikaanse Rivierkreeft",
                ImageUrl = new Uri("https://www.kad.nl/assets/uploads/2020/09/Procambarus-clarkii.jpg"),
                TempMin = 15,
                TempMax = 25,
                PhMin = 6,
                PhMax = 8,
                GhMin = 5,
                GhMax = 12,
                Breedings = new List<Breeding>
                {
                    new Breeding
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "Bijhouden"
                    }
                },
                Continents = new List<Continent>
                {
                    new Continent
                    {
                        Id = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                        Name = "Noord-Amerika"
                    }
                },
                Diets = new List<Diet>
                {
                    new Diet()
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                        Name = "Omnivoor"
                    }
                },
                Kinds = new List<Kind>
                {
                    new Kind
                    {
                        Id = Guid.Parse("20000000-0000-0000-0000-000000000004"),
                        Name = "Kreeft"
                    }
                },
                Socials = new List<Social>
                {
                    new Social
                    {
                        Id = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                        Name = "Koppel"
                    }
                }
            },

            new Animal
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000009"),
                NameFamily = "Cichlidae",
                NameDutch = "Gele Dwergcichlide",
                ImageUrl = new Uri(
                    "https://cdn.myonlinestore.eu/93c794e2-6be1-11e9-a722-44a8421b9960/image/cache/full/05c9e301fc3ecfbdbcfd3a3213b5cb31215d5227.jpg"),
                TempMin = 23,
                TempMax = 29,
                PhMin = 4,
                PhMax = 7,
                GhMin = 5,
                GhMax = 8,
                Breedings = new List<Breeding>
                {
                    new Breeding
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Holenbroeder"
                    }
                },
                Continents = new List<Continent>
                {
                    new Continent
                    {
                        Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                        Name = "Zuid-Amerika"
                    }
                },
                Diets = new List<Diet>
                {
                    new Diet()
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                        Name = "Carnivoor"
                    }
                },
                Kinds = new List<Kind>
                {
                    new Kind
                    {
                        Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                        Name = "Vis"
                    }
                },
                Socials = new List<Social>
                {
                    new Social
                    {
                        Id = Guid.Parse("40000000-0000-0000-0000-000000000005"),
                        Name = "Harem"
                    }
                }
            },

            new Animal
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000010"),
                NameFamily = "Cichlidae",
                NameDutch = "Maanvis",
                ImageUrl = new Uri(
                    "https://www.aquariumfans.nl/wp-content/uploads/2014/04/maanvis-in-actie-1280x720.jpg"),
                TempMin = 24,
                TempMax = 27,
                PhMin = 5,
                PhMax = 6,
                GhMin = 4,
                GhMax = 10,
                Breedings = new List<Breeding>
                {
                    new Breeding
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Substraatbroeder"
                    }
                },
                Continents = new List<Continent>
                {
                    new Continent
                    {
                        Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                        Name = "Zuid-Amerika"
                    }
                },
                Diets = new List<Diet>
                {
                    new Diet()
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                        Name = "Carnivoor"
                    }
                },
                Kinds = new List<Kind>
                {
                    new Kind
                    {
                        Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                        Name = "Vis"
                    }
                },
                Socials = new List<Social>
                {
                    new Social
                    {
                        Id = Guid.Parse("40000000-0000-0000-0000-000000000004"),
                        Name = "School"
                    }
                }
            }
        };

        public IEnumerable<Animal> GetAllAnimals()
        {
            return animals;
        }


        public Animal GetAnimalById(Guid id)
        {
            return animals.FirstOrDefault(a => a.Id == id);
        }

        public async Task<Animal> AddAnimal(Animal animal)
        {
            animals.Add(animal);
            return await Task.FromResult(animal);
        }

        public async Task<Animal> DeleteAnimal(Guid animalId)
        {
            var oldAnimalList = animals.FirstOrDefault(a => a.Id == animalId);
            animals.Remove(oldAnimalList);
            return await Task.FromResult(oldAnimalList);
        }

        public async Task<Animal> UpdateAnimal(Animal animal)
        {
            var oldAnimalList = animals.FirstOrDefault(a => a.Id == animal.Id);
            animals.Remove(oldAnimalList);
            animals.Add(animal);
            return await Task.FromResult(animal);
        }
    }
}