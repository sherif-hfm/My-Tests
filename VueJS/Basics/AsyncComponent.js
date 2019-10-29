import { comp2 } from './comp2.js';
// $.get('component2-comp.html', function (data) {
//     //console.log(data);        
// });
var vm1 = new Vue({
    el: '#app1',
    data: {
        message: 'welcome to vuejs',
        show:false
    },
    methods:{
        doClick(){
            alert('doClick');
        }
    }
});