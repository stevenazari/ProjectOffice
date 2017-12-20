function clearForm(form) {
    form.validator('destroy');
    form.validator('validate');
    form.trigger('reset');
}