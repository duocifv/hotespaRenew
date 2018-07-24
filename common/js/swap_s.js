var __preloadImgs = new Array (
"/common/img/gnav_s_01_on.jpg",
"/common/img/gnav_s_02_on.jpg",
"/common/img/gnav_s_03_on.jpg",
"/common/img/gnav_s_04_on.jpg",
"/common/img/gnav_s_05_on.jpg"
);

var _imgPreloaded = false;

function preloadImg () {
	if (document.images) {
		changeImg ();
		var tmpImgs = new Array ();
		for (var i = 0; i < __preloadImgs.length; i++) {
			tmpImgs [i] = new Image ();
			tmpImgs [i].src = __preloadImgs [i];
		}
		_imgPreloaded = true;
	}
}
var _bakImgs = new Array ();
var _bakImgLen = 0;

function changeImg () {
	var args = arguments;
	if (document.images && _imgPreloaded) {
		if (args.length) {
			for (var i = 0; i < args.length; i += 2) {
				_bakImgs [i] = args [i];
				_bakImgs [i + 1] = document.images [args [i]].src;
				document.images [args [i]].src = args [i + 1];
			}
			_bakImgLen = i;
		} else {
			for (var i = 0; i < _bakImgLen; i += 2) {
				document.images [_bakImgs [i]].src = _bakImgs [i + 1];
			}
		}
	}
}
