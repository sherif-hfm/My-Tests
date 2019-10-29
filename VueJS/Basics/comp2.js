//import { comp4 } from './comp4.js';
export const comp2= Vue.component('comp2', function (resolve, reject) {
        const comp4 = () => ({
                component: import("./comp4.js"),                
              });        
        $.get('comp2.html', function (data) {
                //console.log(data);                
                resolve({
                        template: data,
                        data: function () {
                                return {
                                        comp1Msg: 'Comp2 Data'
                                }
                        },
                        methods:{
                                doClick(){
                                        this.$emit('click')
                                    }
                        },
                        components:{
                                'comp3': () => import('./comp3.js'),
                                //'comp4':  (c) => import("./comp4.js").then( (m)=>{ return m.default(function(r){console.log(r)})} )
                                'comp4':  (c) => import("./comp4.js").then( (m)=>{ console.log(m); return m} )
                                //'comp4':  (c) => import("./comp4.js").then( (m)=>{ return m.default(function(r){ console.log(r); return r})} )
                                 //'comp4':  (c) => import("./comp4.js").then( (m)=>{ console.log(m);return m.default()  } )
                        }
                })
        })
})