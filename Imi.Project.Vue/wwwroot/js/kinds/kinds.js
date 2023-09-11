let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Soorten dieren die in het water leven',
        error: false,
        errorMessage: '',
        kinds: '',
        kindsApiUrl: 'https://localhost:5001/api/Kinds/',
        continentDeleted: false,
    },
    created: async function () {
        var token = localStorage.getItem('token');

        this.kinds = await this.getData(this.kindsApiUrl);
        this.getKinds();
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
                .finally(() => { });
            if (this.error !== true) {
                return response.data;
            }
        },
        getKinds: async function (e) {

            let apiUrl = `${this.kindsApiUrl}`;
            let response = await this.getData(apiUrl);
            this.kinds = response;
        },
        // deletedKind: async function (e) {
        //      this.kindDeleted = false;
        //      let deleteUrl = 'https://localhost:5001/api/Kinds';
        //      const config = {
        //          params: { id: e.currentTarget.id },
        //      };
        //      await axios.delete(deleteUrl, config).then(response => response).catch(error => console.log(error))
        //          .finally(() => this.kindDeleted = true);
        //
        //  }
    }
})