import Vue from 'vue'
import App from './App'
import iView from 'iview'
import JsonViewer from 'vue-json-viewer'
import 'iview/dist/styles/iview.css'
import 'vue-json-viewer/style.css'

Vue.config.productionTip = false
Vue.use(iView)
Vue.use(JsonViewer)
/* eslint-disable no-new */
new Vue({
  el: '#app',
  render: h => h(App)
})
