var app = new Vue({

    el: '#app',
    data: {
        pageTitle: 'Maak nieuw dier aan...',
        animalModel: {
            nameDutch: 'Apistogramma cacatuoides – Gekuifde Dwergcichlide',
            nameFamily: 'Cichlidae',
            breedingId: 4,
            continentId: 4,
            dietId: 1,
            kindId: 1,
            socialId: 4,
            tempMin: 22,
            tempMax: 28,
            phMin: 4,
            phMax: 8,
            ghMin: 5,
            ghMax: 8,
            image: '',
        },
        token: '',
        breedings: '',
        continents: '',
        diets: '',
        kinds: '',
        socials: '',
        error: false,
        userMessage: '',
        success: false,
        animalApiUrl: 'https://localhost:5001/api/Animals/',
        breedingApiUrl: 'https://localhost:5001/api/Breedings/',
        kindsApiUrl: 'https://localhost:5001/api/Kinds/',
        dietApiUrl: 'https://localhost:5001/api/Diets/',
        continentApiUrl: 'https://localhost:5001/api/Continents/',
        socialApiUrl: 'https://localhost:5001/api/Socials/',
        image: '',
        breedingLoaded: '',
        dietLoaded: '',
        continentLoaded: '',
        kindLoaded: '',
        socialLoaded: '',
    },
    created: async function () {
        var token = localStorage.getItem('token');
        this.breedings = await this.getData(this.breedingApiUrl);
        this.diets = await this.getData(this.dietApiUrl);
        this.continents = await this.getData(this.continentApiUrl);
        this.kinds = await this.getData(this.kindsApiUrl);
        this.socials = await this.getData(this.socialApiUrl);
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
        addAnimal: async function () {
            this.error = false;
            this.success = false;
            this.userMessage = '';
            let errorMessage = '';
            let formData = new FormData();
            formData.append('kindId', this.animalModel.kindId);
            formData.append('nameDutch', this.animalModel.nameDutch);
            formData.append('nameFamily', this.animalModel.nameFamily);
            formData.append('continentId', this.animalModel.continentId);
            formData.append('breedingId', this.animalModel.breedingId);
            formData.append('dietId', this.animalModel.dietId);
            formData.append('socialId', this.animalModel.socialId);
            formData.append('tempMin', this.animalModel.tempMin);
            formData.append('tempMax', this.animalModel.tempMax);
            formData.append('phMin', this.animalModel.phMin);
            formData.append('phMax', this.animalModel.phMax);
            formData.append('ghMin', this.animalModel.ghMin);
            formData.append('ghMax', this.animalModel.ghMax);

            this.image = this.$refs.image.files[0];
            formData.append('image', this.image);

            const headers = {
                headers: {
                    Authorization: "Bearer " + localStorage.getItem('token')
                }
            };
            let response = await axios.post(this.animalApiUrl, formData, headers)
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
                this.userMessage = 'Animal added!';
            }
        }

    }
});