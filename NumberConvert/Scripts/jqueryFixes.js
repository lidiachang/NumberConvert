
$.validator.methods.max = function (value, element, param) {
    var globalizedValue = value.replace(",", ".");
    return this.optional(element) || globalizedValue <= param;
}
$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
}