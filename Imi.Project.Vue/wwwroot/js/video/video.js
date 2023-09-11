var app = new Vue({
    el: '#app',
    data: {
        isHidden: false,
        feedback: '',
        searchKey: '',
        videos: null,
        videoRequests: {
            "kind": "youtube#searchResult",
            "etag": "USrqLocD88uBvxWJF1Ti0Yb7MFV",
            "id": {
                "kind": "youtube#video",
                "videoId": "ozhbct75UBg",
            },
            "snippet": {
                "title": "Aquascape Tutorial: IKEBANA BETTA FISH Cube Aquarium (How To: Full Step By Step Planted Tank Guide)",
                "description": "Aquascape Tutorial: IKEBANA BETTA FISH Cube Aquarium (How To: Full Step By Step Planted Tank Guide)",
                "thumbnails": {
                    "high": {
                        "url": "https://i.ytimg.com/vi/ozhbct75UBg/hq720.jpg?sqp=-oaymwEcCNAFEJQDSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLA3Dsn74-6M2if4BUWqPE5pDLxiTg",
                        "width": 480,
                        "height": 360
                    }
                }
            },
            "channelTitle": "MD Fish Tanks",
            "liveBroadcastContent": "none"
        },
        waitListLink: '',
    },
    methods: {
        fetchVideos: function () {
            let self = this;
            let apiUrlYoutube = 'https://youtube.googleapis.com/youtube/v3/search?part=snippet&maxResults=10&order=videoCount&key=AIzaSyDqti2zDWe8ghpr9ul99BE9pog6azbXS4Q';
            let tokenAPI = 'AIzaSyDqti2zDWe8ghpr9ul99BE9pog6azbXS4Q';
            let link= 'https://www.youtube.com/watch?v=';
            var apiUrl = `${apiUrlYoutube}/${self.searchKey}`;
            axios.get(apiUrl)
                .then(function (response) {
                    self.videos = response.data.items;
                    self.isHidden = true;
                })
                .catch(function (error) {
                    console.error(error);
                });
        }
    },
    addToWaitingList: function (video) {
        var self = this;
        self.videoRequests = video;
        self.waitListLink = `https://www.youtube.com/watch?v=${video.id.videoId}`;
        console.log(waitListLink);
        self.isHidden = false;
        console.log(video.id);
    },
});