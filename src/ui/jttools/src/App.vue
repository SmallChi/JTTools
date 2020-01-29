<template>
  <div id="app">
    <div class="layout">
      <div class="ivu-layout">
        <!-- header -->
        <div class="ivu-layout-header">
          <ul class="ivu-menu ivu-menu-horizontal">
            <div class="layout-logo">SmallChi</div>
            <div class="layout-nav">
              <li class="ivu-menu-item ivu-menu-item-active ivu-menu-item-selected">
                <a href="index.html" class>JTTools在线解析</a>
              </li>
              <li class="ivu-menu-item">
                <iframe id="github-star" style="border:none;vertical-align: middle;" width="105" height="20" src="https://ghbtns.com/github-btn.html?user=SmallChi&amp;repo=JTTools&amp;type=watch&amp;count=true"></iframe>
              </li>
            </div>
          </ul>
        </div>
        <!-- End header -->
        <div class="ivu-layout-content" style="padding: 0px 70px;margin-top: 20px">
          <div class="ivu-card ivu-card-bordered">
            <div class="ivu-card-body">
              <div style="min-height: 200px;">
                <tabs value="name1">
                  <tab-pane label="JT808解析工具" name="name1">
                    <div class="pane-content">
                      <div class="left">
                        <i-input
                          v-model="parse808Parameter.HexData"
                          type="textarea"
                          placeholder="Enter Hex Data..."
                          style="resize:none"
                        />
                      </div>
                      <div class="center">
                        <i-button @click="parse808Click" type="primary">
                          <Icon type="ios-arrow-forward" />
                        </i-button>
                      </div>
                      <div class="right">
                        <json-viewer copyable :expand-depth=5 :value="parse808Result"></json-viewer>
                      </div>
                    </div>
                  </tab-pane>
                  <tab-pane :label="tabLabel"  name="name4">
                    <div class="pane-content">
                      <div class="left">
                        <i-input
                          v-model="analyze808arameter.HexData"
                          type="textarea"
                          placeholder="Enter Hex Data..."
                          style="resize:none"
                        />
                      </div>
                      <div class="center">
                        <i-button @click="analyze808Click" type="primary">
                          <Icon type="ios-arrow-forward" />
                        </i-button>
                      </div>
                      <div class="right">
                        <json-viewer copyable :expand-depth=5 :value="analyze808Result"></json-viewer>
                      </div>
                    </div>
                  </tab-pane>
                  <tab-pane label="JT809解析工具" name="name2">
                    <div class="pane-content">
                      <div class="left">
                        <i-input
                          v-model="parse809Parameter.HexData"
                          type="textarea"
                          placeholder="Enter Hex Data..."
                          style="resize:none"
                        />
                      </div>
                      <div class="center">
                        <i-button @click="parse809Click" type="primary">
                          <Icon type="ios-arrow-forward" />
                        </i-button>
                      </div>
                      <div class="right">
                        <json-viewer copyable :expand-depth=5 :value="parse809Result"></json-viewer>
                      </div>
                    </div>
                  </tab-pane>
                  <tab-pane label="JT1078解析工具" name="name3">
                    <div class="pane-content">
                      <div class="left">
                        <i-input
                          v-model="parse1078Parameter.HexData"
                          type="textarea"
                          placeholder="Enter Hex Data..."
                          style="resize:none"
                        />
                      </div>
                      <div class="center">
                        <i-button @click="parse1078Click" type="primary">
                          <Icon type="ios-arrow-forward" />
                        </i-button>
                      </div>
                      <div class="right">
                           <json-viewer copyable :expand-depth=5 :value="parse1078Result"></json-viewer>
                      </div>
                    </div>
                  </tab-pane>
                </tabs>
              </div>
            </div>
          </div>
        </div>
        <div
          class="layout-footer-center ivu-layout-footer"
        >Copyright © 2015-2019 SmallChi. All Rights Reserved. 粤ICP备19128140号</div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'App',
  data () {
    return {
      tabLabel: (h) => {
        return h('div', [
          h('span', 'JT808分析工具'),
          h('Badge', {
            props: {
              dot: true
            }
          })
        ])
      },
      parse808Parameter: {
        HexData: '7E 02 00 00 26 12 34 56 78 90 12 00 7D 02 00 00 00 01 00 00 00 02 00 BA 7F 0E 07 E4 F1 1C 00 28 00 3C 00 00 18 10 15 10 10 10 01 04 00 00 00 64 02 02 00 7D 01 13 7E'
      },
      analyze808arameter: {
        HexData: '7E 02 00 00 26 12 34 56 78 90 12 00 7D 02 00 00 00 01 00 00 00 02 00 BA 7F 0E 07 E4 F1 1C 00 28 00 3C 00 00 18 10 15 10 10 10 01 04 00 00 00 64 02 02 00 7D 01 13 7E'
      },
      parse809Parameter: {
        HexData: '5B 00 00 00 92 00 00 06 82 94 00 01 33 EF B8 01 00 00 00 00 00 27 0F D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 02 94 01 00 00 00 5C 01 00 02 00 00 00 00 5A 01 AC 3F 40 12 3F FA A1 00 00 00 00 5A 01 AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 BA D8 5D'
      },
      parse1078Parameter: {
        HexData: '30 31 63 64 81 E2 10 88 01 12 34 56 78 10 01 10 00 00 01 6B B3 92 CA 7C 02 80 00 28 00 2E 00 00 00 01 61 E1 A2 BF 00 98 CF C0 EE 1E 17 28 34 07 78 8E 39 A4 03 FD DB D1 D5 46 BF B0 63 01 3F 59 AC 34 C9 7A 02 1A B9 6A 28 A4 2C 08'
      },
      parse808Result: '',
      analyze808Result: '',
      parse809Result: '',
      parse1078Result: '',
      apiUrl: 'https://jttools.smallchi.cn/api'
      // apiUrl: 'http://localhost:18888/api'
    }
  },
  mounted () {},
  methods: {
    parse808Click () {
      if (!this.parse808Parameter) return
      this.$Loading.start()
      axios
        .post(this.apiUrl + '/JTTools/Parse808', this.parse808Parameter)
        .then(response => {
          if (response.data.Code === 200) {
            this.parse808Result = response.data.Data
          } else {
            this.parse808Result = response.data.Message
          }
          this.$Loading.finish()
        })
        .catch(error => {
          this.parse808Result = JSON.stringify(error)
          this.$Loading.error()
        })
    },
    analyze808Click () {
      if (!this.analyze808arameter) return
      this.$Loading.start()
      axios
        .post(this.apiUrl + '/JTTools/Analyze808', this.analyze808arameter)
        .then(response => {
          if (response.data.Code === 200) {
            this.analyze808Result = JSON.parse(response.data.Data)
          } else {
            this.analyze808Result = response.data.Message
          }
          this.$Loading.finish()
        })
        .catch(error => {
          this.analyze808Result = JSON.stringify(error)
          this.$Loading.error()
        })
    },
    parse809Click () {
      if (!this.parse809Parameter) return
      this.$Loading.start()
      axios
        .post(this.apiUrl + '/JTTools/Parse809', this.parse809Parameter)
        .then(response => {
          if (response.data.Code === 200) {
            this.parse809Result = response.data.Data
          } else {
            this.parse809Result = response.data.Message
          }
          this.$Loading.finish()
        })
        .catch(error => {
          this.parse809Result = JSON.stringify(error)
          this.$Loading.error()
        })
    },
    parse1078Click () {
      if (!this.parse1078Parameter) return
      this.$Loading.start()
      axios
        .post(this.apiUrl + '/JTTools/Parse1078', this.parse1078Parameter)
        .then(response => {
          if (response.data.Code === 200) {
            this.parse1078Result = response.data.Data
          } else {
            this.parse1078Result = response.data.Message
          }
          this.$Loading.finish()
        })
        .catch(error => {
          this.parse1078Result = JSON.stringify(error)
          this.$Loading.error()
        })
    }
  }
}
</script>

<style scope>
.layout {
  border: 1px solid #d7dde4;
  background: #f5f7f9;
  position: relative;
  border-radius: 0px;
  overflow: hidden;
}

.ivu-layout {
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  -webkit-box-orient: vertical;
  -webkit-box-direction: normal;
  -ms-flex-direction: column;
  flex-direction: column;
  -webkit-box-flex: 1;
  -ms-flex: auto;
  flex: auto;
  background: #f5f7f9;
}

.ivu-layout-header {
  background: #2e8cf0!important;
  padding: 0 50px;
  height: 60px;
  line-height: 60px;
}
.ivu-badge{top: -15px;
    right: -10px;}
.ivu-menu-horizontal {
  height: 60px;
  line-height: 60px;
}

.ivu-menu {
  display: block;
  margin: 0;
  padding: 0;
  outline: 0;
  list-style: none;
  color: #515a6e;
  font-size: 14px;
  position: relative;
  z-index: 900;
}

.ivu-menu a {
  color: #ccc;
}

ivu-menu a:hover,
.ivu-menu-item-active a {
  color: #fff;
}

.layout-logo {
  height: 30px;
  border-radius: 3px;
  float: left;
  position: relative;
  top: 15px;
  left: 20px;
  color: #fff;
  line-height: 30px;
  font-size: 24px;
  font-weight: 400;
}

.layout-nav {
  width: 320px;
  margin: 0 auto;
  margin-right: 20px;
  display: flex;
}

.ivu-menu-item a {
  display: inline-block;
}

.ivu-menu-item {
  font-size: 16px;
  font-weight: 500;
}
.ivu-card-body{
  padding: 0!important;
}
.layout-footer-center {
  text-align: center;
}

.pane-content {
  width: 100%;
  display: flex;
  display: -webkit-flex;
  align-items: center;
  justify-content: center;
  height: calc(100vh - 210px);
  padding: 20px 20px;
}

.ivu-tabs-bar {
  margin-bottom: 0!important;
}

.left, .right {
    width: 45%;
    height: 100%;
    display: inline-block;
    overflow: auto;
}
.right {
    border: 1px solid #ccc;
    border-radius: 4px;
}
.center {
  width: 10%;
  display: flex;
  display: -webkit-flex;
  align-items: center;
  justify-content: center;
}

textarea.ivu-input {
  max-height: 100%;
  min-height: 32px;
  height: 100%!important;
}

.ivu-input-wrapper {
  height: 100%;
}

.ivu-card-body {
  padding: 0;
}

.ivu-tabs-nav .ivu-tabs-tab {
  padding: 16px!important;
  /*margin-right: 0px;*/
}

.ivu-tabs-nav .ivu-tabs-tab-active {
  color: #2d8cf0;
  background: #f0faff;
}

@media (max-width: 1024px) {
  .left,
  .right {
    width: 40%;
  }

  .center {
    width: 20%;
  }
}
</style>
