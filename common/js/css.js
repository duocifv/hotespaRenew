var os = (navigator.appVersion.indexOf ("Win", 0) != -1) ? "w" : "m";
var br = (navigator.appName.indexOf ("Mic", 0) != -1) ? "e" : "n";
document.write ('<link rel="STYLESHEET" type="text/css" href="/common/css/' + os + '_' + br + '.css" title="dormy css">');