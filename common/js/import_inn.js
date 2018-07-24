/****************************** DO NOT EDIT BELOW *****************************/
(function() {
 var jsfiles = ["jquery-1.7.2.min.js", "inq.js","rollover2.js","jquery.page-scroller.js","jquery.belatedPNG.js"];  // Load Script
 
 /****************************** DO NOT EDIT BELOW *****************************/
 function lastof(es)    { return es[es.length - 1]; }
 function dirname(path) { return path.substring(0, path.lastIndexOf('/')); }
 var prefix = dirname(lastof(document.getElementsByTagName('script')).src);
 for(var i = 0; i < jsfiles.length; i++) {
  document.write('<script type="text/javascript" src="' + prefix + '/' + jsfiles[i] + '" charset="utf-8"></script>');
 }
}).call(this);
