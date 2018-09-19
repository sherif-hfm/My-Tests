/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

function Scan(){
    QRScanner.prepare(onDone);
}

function onDone(err, status){
    if (err) {
     // here we can handle errors and clean up any loose ends. 
     console.error(err);
    }
    if (status.authorized) {
      // W00t, you have camera access and the scanner is initialized. 
      // QRscanner.show() should feel very fast. 
      console.log('status.authorized');
      $("#divScan").hide();
      $("#divCam").show();
      QRScanner.show(function(status){         
        console.log('show' + status);
      });
      QRScanner.scan(displayContents);
    } 
    else if (status.denied) {
     // The video preview will remain black, and scanning is disabled. We can 
     // try to ask the user to change their mind, but we'll have to send them 
     // to their device settings with `QRScanner.openSettings()`. 
     console.log('status.denied');
    } 
    else {
        console.log('else');
      // we didn't get permission, but we didn't get permanently denied. (On 
      // Android, a denial isn't permanent unless the user checks the "Don't 
      // ask again" box.) We can ask again at the next relevant opportunity. 
    }
  }

  function displayContents(err, text){
    if(err){
        console.log('error' + err);
    } else {
      // The scan completed, display the contents of the QR code: 
      QRScanner.hide();
      QRScanner.cancelScan();
      $("#divScan").show();
      $("#divCam").hide();
      $("#QrText").text(text);      
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
        this.receivedEvent('deviceready');
    },

    // Update DOM on a Received Event
    receivedEvent: function(id) {
        var parentElement = document.getElementById(id);
        var listeningElement = parentElement.querySelector('.listening');
        var receivedElement = parentElement.querySelector('.received');

        listeningElement.setAttribute('style', 'display:none;');
        receivedElement.setAttribute('style', 'display:block;');

        console.log('Received Event: ' + id);
    }
};

app.initialize();