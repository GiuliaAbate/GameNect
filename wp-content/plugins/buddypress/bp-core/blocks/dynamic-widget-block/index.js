(()=>{"use strict";var t={d:(e,o)=>{for(var s in o)t.o(o,s)&&!t.o(e,s)&&Object.defineProperty(e,s,{enumerable:!0,get:o[s]})},o:(t,e)=>Object.prototype.hasOwnProperty.call(t,e),r:t=>{"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})}},e={};t.r(e),t.d(e,{default:()=>l,dynamicWidgetBlock:()=>i});const o=window.lodash,s=window.wp.url;class i{constructor(t,e){const{path:o,root:s,nonce:i}=t;this.path=o,this.root=s,this.nonce=i,this.blocks=e,this.blocks.forEach(((t,e)=>{const{type:o}=t.query_args||"active",{body:s}=t.preloaded||[];this.blocks[e].items={active:[],newest:[],popular:[],alphabetical:[]},!this.blocks[e].items[o].length&&s&&s.length&&(this.blocks[e].items[o]=s)}))}useTemplate(t){return(0,o.template)(document.querySelector("#tmpl-"+t).innerHTML,{evaluate:/<#([\s\S]+?)#>/g,interpolate:/\{\{\{([\s\S]+?)\}\}\}/g,escape:/\{\{([^\}]+?)\}\}(?!\})/g,variable:"data"})}loop(){}getItems(t="active",e=0){this.blocks[e].query_args.type=t,this.blocks[e].items[t].length?this.loop(this.blocks[e].items[t],this.blocks[e].selector,t):fetch((0,s.addQueryArgs)(this.root+this.path,this.blocks[e].query_args),{method:"GET",headers:{"X-WP-Nonce":this.nonce}}).then((t=>t.json())).then((o=>{this.blocks[e].items[t]=o,this.loop(this.blocks[e].items[t],this.blocks[e].selector,t)}))}}const l=i;(window.bp=window.bp||{}).dynamicWidgetBlock=e})();