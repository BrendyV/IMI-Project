let app = new Vue({
    el: '#app',
    data:{
        pageTitle: 'Leefgebieden van de dieren',
        error: false,
        errorMessage: '',
        continents:'',
        continentApiUrl: 'https://localhost:5001/api/Continents/',
        continentDeleted: false,
    },
    created: async function () {
        var token = localStorage.getItem('token');

        this.continents = await this.getData(this.continentApiUrl);
        this.getContinents();
    },
    methods: {
        getData: async function (apiUrl) {
            let response = '';
            const headers = {
                headers: {
                    Authorization: "Bearer "+ localStorage.getItem('token')
                }
            };
            response = await axios.get(apiUrl, headers)
                .then(response => response)
                .catch(error => {
                    this.error = true;
                    this.errorMessage = error;
                })
                .finally(() => { });
            if (this.error !== true) {
                return response.data;
            }
        },
        getContinents: async function (e) {
            
            let apiUrl = `${this.continentApiUrl}`;
            let response = await this.getData(apiUrl);
            this.continents = response;
        },
        // deletedContinent: async function (e) {
        //      this.continentDeleted = false;
        //      let deleteUrl = 'https://localhost:5001/api/Contients';
        //      const config = {
        //          params: { id: e.currentTarget.id },
        //      };
        //     await axios.delete(deleteUrl, config).then(response => response).catch(error => console.log(error))
        //         .finally(() => this.continentDeleted = true);
        //  }
    }
})