// export default  Vue.component('comp4', function (resolve, reject) {
//         $.get('comp4.html', function (data) {
//                 console.log('comp4');
//                 resolve({
//                         template: data,

//                 })
//         })
// })

export default Vue.component('comp4', {
        template: '<div>I am async Comp4! </div>',
        beforeCreate() {
                console.log('beforeCreate');
        }
})

// export default ()=> {
//         console.log('comp4');
//         var comp;
//          return    {default:Vue.component('comp4', {
//                 template: '<div>I am async!</div>',
//                 beforeCreate()
//                 {
//                         comp=this;
//                         console.log('beforeCreate');
//                 }
//               })};
//         }           

// export default  Vue.component('comp4', function (resolve, reject) {
//           console.log('comp4');
//           resolve({
//             template: '<div>I am async!</div>',
//           })

//       })



// export default  Vue.component('comp4', function (resolve, reject) {
//                 console.log('comp4');
//                 //require(['./my-async-component'], resolve);
//                 resolve({                        
//                         template: '<div>I am async Comp4! </div>',
//                 })

// })


// export default {
//         template: '<div>I am async Comp4! </div>',
//         data: function () {
//                 return {
//                         comp1Msg: 'Comp4 Data'
//                 }
//         }
// }

// export default {
//         template: '<div>I am async Comp4! </div>',
//         data: function () {
//                 return {
//                         comp1Msg: 'Comp4 Data'
//                 }
//         }
// }