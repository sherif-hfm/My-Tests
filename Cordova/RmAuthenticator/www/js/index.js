var progressBarOptions = {
    thickness: 10,
    startAngle: 0,
    size: 25,
    value: 0.0,
    fill: {
        color: '#ffa500'
    }
}

    

var app = {
    // Application Constructor
    initialize: function() {
        document.addEventListener('deviceready', this.onDeviceReady.bind(this), false);
    },

    // deviceready Event Handler
    //
    // Bind any cordova events here. Common events are:
    // 'pause', 'resume', etc.
    onDeviceReady: function() {
        initApp();
    }
    
};

app.initialize();

$(function () {
    //initApp();
});
