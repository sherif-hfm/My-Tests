cordova.define('cordova/plugin_list', function(require, exports, module) {
module.exports = [
  {
    "id": "cordova-plugin-android-permissions.Permissions",
    "file": "plugins/cordova-plugin-android-permissions/www/permissions-dummy.js",
    "pluginId": "cordova-plugin-android-permissions",
    "clobbers": [
      "cordova.plugins.permissions"
    ]
  },
  {
    "id": "cordova-plugin-device.device",
    "file": "plugins/cordova-plugin-device/www/device.js",
    "pluginId": "cordova-plugin-device",
    "clobbers": [
      "device"
    ]
  },
  {
    "id": "cordova-plugin-sms.SMS",
    "file": "plugins/cordova-plugin-sms/www/SMS.js",
    "pluginId": "cordova-plugin-sms",
    "clobbers": [
      "window.SMS"
    ]
  }
];
module.exports.metadata = 
// TOP OF METADATA
{
  "cordova-plugin-android-permissions": "1.0.0",
  "cordova-plugin-device": "1.1.7",
  "cordova-plugin-sms": "1.0.5",
  "cordova-plugin-whitelist": "1.3.3"
};
// BOTTOM OF METADATA
});