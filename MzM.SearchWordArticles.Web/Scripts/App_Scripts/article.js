var swa = {};
$(document).ready(function () {

	$.validator.addMethod("containword", function (text) {
		var word = $("#lblword").html();
		var isValidText = swa.ValidateWordIsInText(text, word);
		return isValidText;
	},
	"Please enter the word at least once");

	$("#articleform").validate({
		rules: {
			ntext: {
				required: true,
				containword: true
			}
		},
		focusCleanup: true
	});

	$('#btnCreate').click(function (event) {
		swa.CreateArticle(event);
	});
});

swa.CreateArticle = function (event) {
	var valid = $("#articleform").validate().form();
	if (valid) {
		$("input").prop('disabled', true);
		var text = $("#txttext").val();
		var word = $("#lblword").html();

		var model = { Text: text, SearchWordIds: [word] };
		var json = JSON.stringify(model);

		$.ajax({
			url: '/api/article',
			cache: false,
			type: 'POST',
			data: json,
			contentType: 'application/json; charset=utf-8',
			statusCode: {
				201: function (data) {
					var url = $('#btnCreate').data('returnurl');
					window.location = url + '/' + data.Id;
				}
			}
		});
	}
};

swa.ValidateWordIsInText = function (text, word) {
	var pattern = new RegExp(word, 'i');
	var isMatch = pattern.test(text);
	return isMatch;
}