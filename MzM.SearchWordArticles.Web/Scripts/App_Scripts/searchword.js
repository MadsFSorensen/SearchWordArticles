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

	$('#btnNewSearchWord').click(function (sender) {
		swa.PostSearchWord(sender);
	});
	$('#txtWord').keydown(function (sender) {
		swa.CatchWordEnter(sender);
	});
	$('#txtVolume').keydown(function (sender) {
		swa.CatchVolumeEnter(sender);
	});

	$('#txtWord').focus();

});


swa.CatchWordEnter = function (sender) {
	if (sender.keyCode == 13) {
		var valid= $("#wordform").validate().element("#txtWord");
		if(valid)
			$('#txtVolume').focus();
	}
};

swa.CatchVolumeEnter = function (sender) {
	if (sender.keyCode == 13) {
		var valid = $("#wordform").validate().form();
		if(valid)
		{
			swa.PostSearchWord();
			var validator = $("#wordform").validate();
			validator.resetForm();
			$('#txtWord').focus();
		}
	}
};

swa.PostSearchWord = function () {
	var word = $('#txtWord').val();
	var volume = $('#txtVolume').val();
	var searchWord = { Word: word, Volume: volume };
	$('#txtWord').val('');
	$('#txtVolume').val('');

	var json = JSON.stringify(searchWord);

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