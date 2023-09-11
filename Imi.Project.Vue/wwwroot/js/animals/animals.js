let app = new Vue({

    el: '#app',
    data: {
        pageTitle: 'Dieren',
        isHidden: false,
        kinds: '',
        error: false,
        errorMessage: '',
        animals: '',
        breedingLoaded: false,
        dietLoaded: false,
        continentLoaded: false,
        kindsLoaded: false,
        socialLoaded: false,
        animalKindApiUrl: 'https://localhost:5001/api/Animals/kind/',
        animalBreedingUrl: 'https://localhost:5001/api/Animals/breeding/',
        animalDietUrl: 'https://localhost:5001/api/Animals/diet/',
        animalContinentUrl: 'https://localhost:5001/api/Animals/continent/',
        animalSocialUrl: 'https://localhost:5001/api/Animals/social/',
        animalApiUrl: 'https://localhost:5001/api/Animals/',
        breedingApiUrl: 'https://localhost:5001/api/Breedings/',
        kindsApiUrl: 'https://localhost:5001/api/Kinds/',
        dietApiUrl: 'https://localhost:5001/api/Diets/',
        continentApiUrl: 'https://localhost:5001/api/Continents/',
        socialApiUrl: 'https://localhost:5001/api/Socials/',
        animalDeleted: false,
        selectedKind: '',
        currentAnimal:{
            nameDutch: '',
            nameFamily: '',
            breedingId: '',
            continentId: '',
            dietId: '',
            kindId: '',
            socialId: '',
            tempMin: '',
            tempMax: '',
            phMin: '',
            phMax: '',
            ghMin: '',
            ghMax: '',
        },
        selectedBreeding:'',
        selectedDiet:'',
        selectedContinent:'',
        selectedSocial:'',
    },
    created: async function () {
        var token = localStorage.getItem('token');

        this.breedings = await this.getData(this.breedingApiUrl);
        this.diets = await this.getData(this.dietApiUrl);
        this.continents = await this.getData(this.continentApiUrl);
        this.kinds = await this.getData(this.kindsApiUrl);
        this.socials = await this.getData(this.socialApiUrl);
        this.getAnimals();
    },
    methods: {
        getData: async function (apiUrl) {
            let response = '';
            const headers = {
                headers: {
                    Authorization: "Bearer " + localStorage.getItem('token')
                }
            };
            response = await axios.get(apiUrl, headers)
                .then(response => response)
                .catch(error => {
                    this.error = true;
                    this.errorMessage = error;
                })
                .finally(() => {
                    this.breedingLoaded = true;
                    this.dietLoaded = true;
                    this.continentLoaded = true;
                    this.kindsLoaded = true;
                    this.socialLoaded = true;
                });
            if (this.error !== true) {
                return response.data;
            }
        },
        getAnimals: async function (e) {
            //de if/else is voor de wijziging van select
            if (e === undefined) {
                this.selectedKind = 1;
            } else if (e.currentTarget !== undefined) {
                this.selectedKind = e.currentTarget.value;
            } else {
                this.selectedKind = e.value;
            }

            let apiUrl = `${this.animalKindApiUrl}${this.selectedKind}`;
            let response = await this.getData(apiUrl);
            this.animals = response;
        },
        getAnimalsDetails: function (animal) {
            var self = this;
            self.currentAnimal = animal;
            console.log(animal);
            self.isHidden = true;
        },
        toSaveAnimal: async function () {
            this.error = false;
            this.success = false;
            this.userMessage = '';
            let errorMessage = '';
            const headers = {
                headers: {
                    Authorization: "Bearer " + localStorage.getItem('token')
                }
            };

            let formData = new FormData();

            formData.append('nameDutch', this.currentAnimal.nameDutch);
            formData.append('nameFamily', this.currentAnimal.nameFamily);
            formData.append('breedingId', this.currentAnimal.breedingId);
            formData.append('continentId', this.currentAnimal.continentId);
            formData.append('dietId', this.currentAnimal.dietId);
            formData.append('kindId', this.currentAnimal.kindId);
            formData.append('socialId', this.currentAnimal.socialId);
            formData.append('tempMin', this.currentAnimal.tempMin);
            formData.append('tempMax', this.currentAnimal.tempMax);
            formData.append('phMin', this.currentAnimal.phMin);
            formData.append('phMax', this.currentAnimal.phMax);
            formData.append('ghMin', this.currentAnimal.ghMin);
            formData.append('ghMax', this.currentAnimal.ghMax);

            this.image = this.$refs.image.files[0];
            formData.append('image', this.image);


            let response = await axios.put(this.animalApiUrl, formData, headers)
                .then(response => response)
                .catch(error => {
                    errorMessage = error;
                    this.error = true
                })
                .finally(() => {
                });
            if (this.error === true) {
                this.userMessage = errorMessage;
            } else {
                this.success = true;
                this.userMessage = 'Animal updated!';
            }
        },
        deleteAnimal: function(animal) {
            let self = this;
            let url = `https://localhost:5001/api/Animals/}/${animal.id}`;

            const headers = {
                headers: {
                    Authorization: "Bearer " + localStorage.getItem('token')
                }
            };
            axios.delete(url, headers)
                .then(function(response) {
                    
                })
                .catch(function(error) { console.error(error); })
                .then(function() {
                    setTimeout(function() { self.feedback = null; }, 5000);
                    window.location.reload();
                });
        },
        deleteAnimal: async function (e) {
            this.animalDeleted = false;
            let deleteUrl = 'https://localhost:5001/api/animals/';
            const config = {
                params: {id: e.currentTarget.id},
            };
            await axios.delete(deleteUrl, config)
                .then(response => response)
                .catch(error => console.log(error))
                .finally(() => this.animalDeleted = true);

            this.getAnimals(this.$refs.slcKinds);
        }
    }
});