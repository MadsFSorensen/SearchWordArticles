var swa = {};
var viewModel = { words: ko.observableArray([]) };

$(document).ready(function () {

	$("#wordform").validate({
		rules: {
			nword: {
				required: true,
			},
			nvolume: {
				required: true,
				digits: true
			}
		},
        focusCleanup: true
	});

	ko.applyBindings(viewModel);
	swa.GetSearchWords();

	$('#btnNewSearchWord').click(function (event) {
		swa.PostSearchWord(event);
	});
	$('#txtWord').keydown(function (event) {
		swa.CatchWordEnter(event);
	});
	$('#txtVolume').keydown(function (event) {
		swa.CatchVolumeEnter(event);
	});

	$('#txtWord').focus();

});


swa.CatchWordEnter = function (event) {
	if (event.keyCode == 13) {
		var valid= $("#wordform").validate().element("#txtWord");
		if(valid)
			$('#txtVolume').focus();
	}
};

swa.CatchVolumeEnter = function (event) {
	if (event.keyCode == 13) {
		var valid = $("#wordform").validate().form();
		if(valid)
		{
			swa.PostSearchWord();
			$('#txtWord').focus();
            window.setTimeout(function(){ 
                var validator = $("#wordform").validate();
			    validator.resetForm();
            },100);
		}
	}
};

swa.PostSearchWord = function () {
	var word = $('#txtWord').val();
	var volume = $('#txtVolume').val();
	var model = { Word: word, Volume: volume };
	$('#txtWord').val('');
	$('#txtVolume').val('');

	var json = JSON.stringify(model);

	$.ajax({
		url: '/api/searchword',
		cache: false,
		type: 'POST',
		data: json,
		contentType: 'application/json; charset=utf-8',
		statusCode: {
			201: function (data) {
				viewModel.words.push(data);
			}
		}
	});
};

swa.GetSearchWords = function () {
	viewModel.words([]);
	$.get('/api/searchword', function (data) {
		viewModel.words(data);
	});
};