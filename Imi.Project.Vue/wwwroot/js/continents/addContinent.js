var app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Voeg een nieuw leefgebied toe',
        continentModel: {
            name: ''
        },
        token: '',
        continentApiUrl: 'https://localhost:5001/api/Continents/',
        error: false,
        userMessage: '',
        success: false,
        image: '',
    },
    methods: {
        addContinent: async function () {
            this.error = false;
            this.success = false;
            this.userMessage = '';
            let errorMessage = '';
            let formData = new FormData();

            formData.append('name', this.continentModel.name);

            this.image = this.$refs.image.files[0];
            formData.append('image', this.image);

            const headers = {
                headers: {
                    Authorization: "Bearer " + localStorage.getItem('token')
                }
            };
            let response = await axios.post(this.continentApiUrl, formData, headers)
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
                this.userMessage = 'Continent added!';
            }
        }
    },

});