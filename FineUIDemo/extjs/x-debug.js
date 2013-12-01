/*
    http://www.JSON.org/json2.js
    2011-02-23

    Public Domain.

    NO WARRANTY EXPRESSED OR IMPLIED. USE AT YOUR OWN RISK.

    See http://www.JSON.org/js.html


    This code should be minified before deployment.
    See http://javascript.crockford.com/jsmin.html

    USE YOUR OWN COPY. IT IS EXTREMELY UNWISE TO LOAD CODE FROM SERVERS YOU DO
    NOT CONTROL.


    This file creates a global JSON object containing two methods: stringify
    and parse.

        JSON.stringify(value, replacer, space)
            value       any JavaScript value, usually an object or array.

            replacer    an optional parameter that determines how object
                        values are stringified for objects. It can be a
                        function or an array of strings.

            space       an optional parameter that specifies the indentation
                        of nested structures. If it is omitted, the text will
                        be packed without extra whitespace. If it is a number,
                        it will specify the number of spaces to indent at each
                        level. If it is a string (such as '\t' or '&nbsp;'),
                        it contains the characters used to indent at each level.

            This method produces a JSON text from a JavaScript value.

            When an object value is found, if the object contains a toJSON
            method, its toJSON method will be called and the result will be
            stringified. A toJSON method does not serialize: it returns the
            value represented by the name/value pair that should be serialized,
            or undefined if nothing should be serialized. The toJSON method
            will be passed the key associated with the value, and this will be
            bound to the value

            For example, this would serialize Dates as ISO strings.

                Date.prototype.toJSON = function (key) {
                    function f(n) {
                        // Format integers to have at least two digits.
                        return n < 10 ? '0' + n : n;
                    }

                    return this.getUTCFullYear()   + '-' +
                         f(this.getUTCMonth() + 1) + '-' +
                         f(this.getUTCDate())      + 'T' +
                         f(this.getUTCHours())     + ':' +
                         f(this.getUTCMinutes())   + ':' +
                         f(this.getUTCSeconds())   + 'Z';
                };

            You can provide an optional replacer method. It will be passed the
            key and value of each member, with this bound to the containing
            object. The value that is returned from your method will be
            serialized. If your method returns undefined, then the member will
            be excluded from the serialization.

            If the replacer parameter is an array of strings, then it will be
            used to select the members to be serialized. It filters the results
            such that only members with keys listed in the replacer array are
            stringified.

            Values that do not have JSON representations, such as undefined or
            functions, will not be serialized. Such values in objects will be
            dropped; in arrays they will be replaced with null. You can use
            a replacer function to replace those with JSON values.
            JSON.stringify(undefined) returns undefined.

            The optional space parameter produces a stringification of the
            value that is filled with line breaks and indentation to make it
            easier to read.

            If the space parameter is a non-empty string, then that string will
            be used for indentation. If the space parameter is a number, then
            the indentation will be that many spaces.

            Example:

            text = JSON.stringify(['e', {pluribus: 'unum'}]);
            // text is '["e",{"pluribus":"unum"}]'


            text = JSON.stringify(['e', {pluribus: 'unum'}], null, '\t');
            // text is '[\n\t"e",\n\t{\n\t\t"pluribus": "unum"\n\t}\n]'

            text = JSON.stringify([new Date()], function (key, value) {
                return this[key] instanceof Date ?
                    'Date(' + this[key] + ')' : value;
            });
            // text is '["Date(---current time---)"]'


        JSON.parse(text, reviver)
            This method parses a JSON text to produce an object or array.
            It can throw a SyntaxError exception.

            The optional reviver parameter is a function that can filter and
            transform the results. It receives each of the keys and values,
            and its return value is used instead of the original value.
            If it returns what it received, then the structure is not modified.
            If it returns undefined then the member is deleted.

            Example:

            // Parse the text. Values that look like ISO date strings will
            // be converted to Date objects.

            myData = JSON.parse(text, function (key, value) {
                var a;
                if (typeof value === 'string') {
                    a =
/^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*)?)Z$/.exec(value);
                    if (a) {
                        return new Date(Date.UTC(+a[1], +a[2] - 1, +a[3], +a[4],
                            +a[5], +a[6]));
                    }
                }
                return value;
            });

            myData = JSON.parse('["Date(09/09/2001)"]', function (key, value) {
                var d;
                if (typeof value === 'string' &&
                        value.slice(0, 5) === 'Date(' &&
                        value.slice(-1) === ')') {
                    d = new Date(value.slice(5, -1));
                    if (d) {
                        return d;
                    }
                }
                return value;
            });


    This is a reference implementation. You are free to copy, modify, or
    redistribute.
*/

/*jslint evil: true, strict: false, regexp: false */

/*members "", "\b", "\t", "\n", "\f", "\r", "\"", JSON, "\\", apply,
    call, charCodeAt, getUTCDate, getUTCFullYear, getUTCHours,
    getUTCMinutes, getUTCMonth, getUTCSeconds, hasOwnProperty, join,
    lastIndex, length, parse, prototype, push, replace, slice, stringify,
    test, toJSON, toString, valueOf
*/


// Create a JSON object only if one does not already exist. We create the
// methods in a closure to avoid creating global variables.

var JSON;
if (!JSON) {
    JSON = {};
}

(function () {
    "use strict";

    function f(n) {
        // Format integers to have at least two digits.
        return n < 10 ? '0' + n : n;
    }

    if (typeof Date.prototype.toJSON !== 'function') {

        Date.prototype.toJSON = function (key) {

            return isFinite(this.valueOf()) ?
                this.getUTCFullYear()     + '-' +
                f(this.getUTCMonth() + 1) + '-' +
                f(this.getUTCDate())      + 'T' +
                f(this.getUTCHours())     + ':' +
                f(this.getUTCMinutes())   + ':' +
                f(this.getUTCSeconds())   + 'Z' : null;
        };

        String.prototype.toJSON      =
            Number.prototype.toJSON  =
            Boolean.prototype.toJSON = function (key) {
                return this.valueOf();
            };
    }

    var cx = /[\u0000\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g,
        escapable = /[\\\"\x00-\x1f\x7f-\x9f\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g,
        gap,
        indent,
        meta = {    // table of character substitutions
            '\b': '\\b',
            '\t': '\\t',
            '\n': '\\n',
            '\f': '\\f',
            '\r': '\\r',
            '"' : '\\"',
            '\\': '\\\\'
        },
        rep;


    function quote(string) {

// If the string contains no control characters, no quote characters, and no
// backslash characters, then we can safely slap some quotes around it.
// Otherwise we must also replace the offending characters with safe escape
// sequences.

        escapable.lastIndex = 0;
        return escapable.test(string) ? '"' + string.replace(escapable, function (a) {
            var c = meta[a];
            return typeof c === 'string' ? c :
                '\\u' + ('0000' + a.charCodeAt(0).toString(16)).slice(-4);
        }) + '"' : '"' + string + '"';
    }


    function str(key, holder) {

// Produce a string from holder[key].

        var i,          // The loop counter.
            k,          // The member key.
            v,          // The member value.
            length,
            mind = gap,
            partial,
            value = holder[key];

// If the value has a toJSON method, call it to obtain a replacement value.

        if (value && typeof value === 'object' &&
                typeof value.toJSON === 'function') {
            value = value.toJSON(key);
        }

// If we were called with a replacer function, then call the replacer to
// obtain a replacement value.

        if (typeof rep === 'function') {
            value = rep.call(holder, key, value);
        }

// What happens next depends on the value's type.

        switch (typeof value) {
        case 'string':
            return quote(value);

        case 'number':

// JSON numbers must be finite. Encode non-finite numbers as null.

            return isFinite(value) ? String(value) : 'null';

        case 'boolean':
        case 'null':

// If the value is a boolean or null, convert it to a string. Note:
// typeof null does not produce 'null'. The case is included here in
// the remote chance that this gets fixed someday.

            return String(value);

// If the type is 'object', we might be dealing with an object or an array or
// null.

        case 'object':

// Due to a specification blunder in ECMAScript, typeof null is 'object',
// so watch out for that case.

            if (!value) {
                return 'null';
            }

// Make an array to hold the partial results of stringifying this object value.

            gap += indent;
            partial = [];

// Is the value an array?

            if (Object.prototype.toString.apply(value) === '[object Array]') {

// The value is an array. Stringify every element. Use null as a placeholder
// for non-JSON values.

                length = value.length;
                for (i = 0; i < length; i += 1) {
                    partial[i] = str(i, value) || 'null';
                }

// Join all of the elements together, separated with commas, and wrap them in
// brackets.

                v = partial.length === 0 ? '[]' : gap ?
                    '[\n' + gap + partial.join(',\n' + gap) + '\n' + mind + ']' :
                    '[' + partial.join(',') + ']';
                gap = mind;
                return v;
            }

// If the replacer is an array, use it to select the members to be stringified.

            if (rep && typeof rep === 'object') {
                length = rep.length;
                for (i = 0; i < length; i += 1) {
                    if (typeof rep[i] === 'string') {
                        k = rep[i];
                        v = str(k, value);
                        if (v) {
                            partial.push(quote(k) + (gap ? ': ' : ':') + v);
                        }
                    }
                }
            } else {

// Otherwise, iterate through all of the keys in the object.

                for (k in value) {
                    if (Object.prototype.hasOwnProperty.call(value, k)) {
                        v = str(k, value);
                        if (v) {
                            partial.push(quote(k) + (gap ? ': ' : ':') + v);
                        }
                    }
                }
            }

// Join all of the member texts together, separated with commas,
// and wrap them in braces.

            v = partial.length === 0 ? '{}' : gap ?
                '{\n' + gap + partial.join(',\n' + gap) + '\n' + mind + '}' :
                '{' + partial.join(',') + '}';
            gap = mind;
            return v;
        }
    }

// If the JSON object does not yet have a stringify method, give it one.

    if (typeof JSON.stringify !== 'function') {
        JSON.stringify = function (value, replacer, space) {

// The stringify method takes a value and an optional replacer, and an optional
// space parameter, and returns a JSON text. The replacer can be a function
// that can replace values, or an array of strings that will select the keys.
// A default replacer method can be provided. Use of the space parameter can
// produce text that is more easily readable.

            var i;
            gap = '';
            indent = '';

// If the space parameter is a number, make an indent string containing that
// many spaces.

            if (typeof space === 'number') {
                for (i = 0; i < space; i += 1) {
                    indent += ' ';
                }

// If the space parameter is a string, it will be used as the indent string.

            } else if (typeof space === 'string') {
                indent = space;
            }

// If there is a replacer, it must be a function or an array.
// Otherwise, throw an error.

            rep = replacer;
            if (replacer && typeof replacer !== 'function' &&
                    (typeof replacer !== 'object' ||
                    typeof replacer.length !== 'number')) {
                throw new Error('JSON.stringify');
            }

// Make a fake root object containing our value under the key of ''.
// Return the result of stringifying the value.

            return str('', {'': value});
        };
    }


// If the JSON object does not yet have a parse method, give it one.

    if (typeof JSON.parse !== 'function') {
        JSON.parse = function (text, reviver) {

// The parse method takes a text and an optional reviver function, and returns
// a JavaScript value if the text is a valid JSON text.

            var j;

            function walk(holder, key) {

// The walk method is used to recursively walk the resulting structure so
// that modifications can be made.

                var k, v, value = holder[key];
                if (value && typeof value === 'object') {
                    for (k in value) {
                        if (Object.prototype.hasOwnProperty.call(value, k)) {
                            v = walk(value, k);
                            if (v !== undefined) {
                                value[k] = v;
                            } else {
                                delete value[k];
                            }
                        }
                    }
                }
                return reviver.call(holder, key, value);
            }


// Parsing happens in four stages. In the first stage, we replace certain
// Unicode characters with escape sequences. JavaScript handles many characters
// incorrectly, either silently deleting them, or treating them as line endings.

            text = String(text);
            cx.lastIndex = 0;
            if (cx.test(text)) {
                text = text.replace(cx, function (a) {
                    return '\\u' +
                        ('0000' + a.charCodeAt(0).toString(16)).slice(-4);
                });
            }

// In the second stage, we run the text against regular expressions that look
// for non-JSON patterns. We are especially concerned with '()' and 'new'
// because they can cause invocation, and '=' because it can cause mutation.
// But just to be safe, we want to reject all unexpected forms.

// We split the second stage into 4 regexp operations in order to work around
// crippling inefficiencies in IE's and Safari's regexp engines. First we
// replace the JSON backslash pairs with '@' (a non-JSON character). Second, we
// replace all simple value tokens with ']' characters. Third, we delete all
// open brackets that follow a colon or comma or that begin the text. Finally,
// we look to see that the remaining characters are only whitespace or ']' or
// ',' or ':' or '{' or '}'. If that is so, then the text is safe for eval.

            if (/^[\],:{}\s]*$/
                    .test(text.replace(/\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g, '@')
                        .replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, ']')
                        .replace(/(?:^|:|,)(?:\s*\[)+/g, ''))) {

// In the third stage we use the eval function to compile the text into a
// JavaScript structure. The '{' operator is subject to a syntactic ambiguity
// in JavaScript: it can begin a block or an object literal. We wrap the text
// in parens to eliminate the ambiguity.

                j = eval('(' + text + ')');

// In the optional fourth stage, we recursively walk the new structure, passing
// each name/value pair to a reviver function for possible transformation.

                return typeof reviver === 'function' ?
                    walk({'': j}, '') : j;
            }

// If the text is not JSON parseable, then a SyntaxError is thrown.

            throw new SyntaxError('JSON.parse');
        };
    }
}());
﻿/**
*
*  Base64 encode / decode
*  http://www.webtoolkit.info/
*
**/

var Base64 = {

    // private property
    _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",

    // public method for encoding
    encode: function(input) {
        var output = "";
        var chr1, chr2, chr3, enc1, enc2, enc3, enc4;
        var i = 0;

        input = Base64._utf8_encode(input);

        while (i < input.length) {

            chr1 = input.charCodeAt(i++);
            chr2 = input.charCodeAt(i++);
            chr3 = input.charCodeAt(i++);

            enc1 = chr1 >> 2;
            enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
            enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
            enc4 = chr3 & 63;

            if (isNaN(chr2)) {
                enc3 = enc4 = 64;
            } else if (isNaN(chr3)) {
                enc4 = 64;
            }

            output = output +
			this._keyStr.charAt(enc1) + this._keyStr.charAt(enc2) +
			this._keyStr.charAt(enc3) + this._keyStr.charAt(enc4);

        }

        return output;
    },

    // public method for decoding
    decode: function(input) {
        var output = "";
        var chr1, chr2, chr3;
        var enc1, enc2, enc3, enc4;
        var i = 0;

        input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

        while (i < input.length) {

            enc1 = this._keyStr.indexOf(input.charAt(i++));
            enc2 = this._keyStr.indexOf(input.charAt(i++));
            enc3 = this._keyStr.indexOf(input.charAt(i++));
            enc4 = this._keyStr.indexOf(input.charAt(i++));

            chr1 = (enc1 << 2) | (enc2 >> 4);
            chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
            chr3 = ((enc3 & 3) << 6) | enc4;

            output = output + String.fromCharCode(chr1);

            if (enc3 != 64) {
                output = output + String.fromCharCode(chr2);
            }
            if (enc4 != 64) {
                output = output + String.fromCharCode(chr3);
            }

        }

        output = Base64._utf8_decode(output);

        return output;

    },

    // private method for UTF-8 encoding
    _utf8_encode: function(string) {
        string = string.replace(/\r\n/g, "\n");
        var utftext = "";

        for (var n = 0; n < string.length; n++) {

            var c = string.charCodeAt(n);

            if (c < 128) {
                utftext += String.fromCharCode(c);
            }
            else if ((c > 127) && (c < 2048)) {
                utftext += String.fromCharCode((c >> 6) | 192);
                utftext += String.fromCharCode((c & 63) | 128);
            }
            else {
                utftext += String.fromCharCode((c >> 12) | 224);
                utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                utftext += String.fromCharCode((c & 63) | 128);
            }

        }

        return utftext;
    },

    // private method for UTF-8 decoding
    _utf8_decode: function(utftext) {
        var string = "";
        var i = 0;
        var c = c1 = c2 = 0;

        while (i < utftext.length) {

            c = utftext.charCodeAt(i);

            if (c < 128) {
                string += String.fromCharCode(c);
                i++;
            }
            else if ((c > 191) && (c < 224)) {
                c2 = utftext.charCodeAt(i + 1);
                string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));
                i += 2;
            }
            else {
                c2 = utftext.charCodeAt(i + 1);
                c3 = utftext.charCodeAt(i + 2);
                string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
                i += 3;
            }

        }

        return string;
    }

};
// FineUI应用程序域
var X = function (cmpName) {
    return Ext.getCmp(cmpName);
};

X.state = function (cmp, state) {
    X.util.setXState(cmp, state);
};

X.enable = function (id) {
    X.util.enableSubmitControl(id);
};

X.disable = function (id) {
    X.util.disableSubmitControl(id);
};

X.target = function (target) {
    return X.util.getTargetWindow(target);
};

X.alert = function () {
    X.util.alert.apply(window, arguments);
};

X.init = function () {
    if (typeof (onInit) == 'function') {
        onInit();
    }
};

X.ready = function () {
    if (typeof (onReady) == 'function') {
        onReady();
    }
};

X.ajaxReady = function () {
    if (typeof (onAjaxReady) == 'function') {
        onAjaxReady();
    }
};

X.stop = function () {
    var event = arguments.callee.caller.arguments[0] || window.event;
    X.util.stopEventPropagation(event);
};

X.confirm = function () {
	X.util.confirm.apply(null, arguments);
};

X.toggle = function (el, className) {
    Ext.get(el).toggleClass(className);
};


(function () {


    // FineUI常用函数域（Utility）
    X.util = {

        alertTitle: "Alert Dialog",
        confirmTitle: "Confirm Dialog",
        formAlertMsg: "Please provide valid value for {0}!",
        formAlertTitle: "Form Invalid",
        loading: "Loading...",

        // 下拉列表的模板
        ddlTPL: '<tpl for="."><div class="x-combo-list-item <tpl if="!enabled">x-combo-list-item-disable</tpl>">{prefix}{text}</div></tpl>',

		// 初始化
        init: function (msgTarget, labelWidth, labelSeparator, enableBigFont,
            blankImageUrl, enableAjaxLoading, ajaxLoadingType, enableAjax) {
            // Ext.QuickTips.init(true); 在原生的IE7（非IE8下的IE7模式）会有问题
            // 表现为iframe中的页面出现滚动条时，页面上的所有按钮都不能点击了。
            // 测试例子在：aspnet/test.aspx
            Ext.QuickTips.init(false);

            X.ajax.hookPostBack();
            //if (enableAspnetSubmitButtonAjax) {
            //    X.util.makeAspnetSubmitButtonAjax();
            //}

            X.global_enable_ajax = enableAjax;

            X.global_enable_ajax_loading = enableAjaxLoading;
            X.global_ajax_loading_type = ajaxLoadingType;

            // 添加Ajax Loading提示节点
            X.ajaxLoadingDefault = Ext.get(X.util.appendLoadingNode());
            X.ajaxLoadingMask = new Ext.LoadMask(Ext.getBody(), { msg: X.util.loading });


            X.form_upload_file = false;
            X.global_disable_ajax = false;
            X.window_default_group = new Ext.WindowGroup();
            X.window_default_group.zseed = 6000;
            X.util.setHiddenFieldValue('X_CHANGED', 'false');
            document.forms[0].autocomplete = 'off';

            if (Ext.form.Field) {
                // Form cofiguration
                var fieldPro = Ext.form.Field.prototype;
                // editorPro = Ext.form.HtmlEditor.prototype;
                fieldPro.msgTarget = msgTarget;
                fieldPro.labelWidth = labelWidth;
                fieldPro.labelSeparator = labelSeparator;
                fieldPro.autoFitErrors = false;
            }

            if (enableBigFont) {
                Ext.getBody().addClass('bigfont');
            }

            // Default empty image
            if (Ext.isIE6 || Ext.isIE7) {
                Ext.BLANK_IMAGE_URL = blankImageUrl;
            }

            //            // 页面缩放时改变页面上所有Window控件的容器大小
            //            Ext.EventManager.onWindowResize(function(w, h){
            //                var viewSize = window.Ext.getBody().getViewSize();
            //                Ext.select('.x-window-wrapper').setWidth(viewSize.width).setHeight(viewSize.height);       
            //            });
        },


        setXState: function (cmp, state) {
            if (!cmp || !cmp['x_state']) {
                return;
            }

            var oldValue, newValue, el;
            // 如果state中包含CssClass，也就是在服务器端修改了CssClass属性，则需要首先删除原来的CssClass属性。
            if (typeof (state['CssClass']) !== 'undefined') {
                newValue = state['CssClass'];
                oldValue = cmp['x_state']['CssClass'];
                if (!oldValue) {
                    oldValue = cmp.initialConfig.cls;
                }
                el = cmp.el;
                el.removeClass(oldValue);
                el.addClass(newValue);
            }

            if (typeof (state['FormItemClass']) !== 'undefined') {
                newValue = state['FormItemClass'];
                oldValue = cmp['x_state']['FormItemClass'];
                if (!oldValue) {
                    oldValue = cmp.initialConfig.itemCls;
                }
                // Search for max 10 depth.
                el = cmp.el.findParent('.x-form-item', 10, true);
                el.removeClass(oldValue);
                el.addClass(newValue);
            }

            Ext.apply(cmp['x_state'], state);

        },

        stopEventPropagation: function (event) {
            event = event || window.event;
            if (typeof (event.cancelBubble) === 'boolean') {
                event.cancelBubble = true;
            } else {
                event.stopPropagation();
            }
        },

        // 绑定函数的上下文
        bind: function (fn, scope) {
            return function () {
                return fn.apply(scope, arguments);
            };
        },

        // 在页面上查找id为findId的节点，替换成replaceHtml
        replace: function (findId, replaceHtml) {
            // 在findId外面添加一个DIV层，然后更新此wrapper的InnerHTML
            var findedControl = Ext.get(findId);
            if (findedControl) {
                var wrapper = findedControl.wrap().update(replaceHtml);
                // 将新增的节点移到wrapper上面
                wrapper.first().insertBefore(wrapper);
                // 然后删除wrapper
                wrapper.remove();
            }
        },

        // 去除PageLoading节点
        removePageLoading: function (fadeOut) {
            if (fadeOut) {
                Ext.get("loading").remove();
                Ext.get("loading-mask").fadeOut({ remove: true });
            }
            else {
                Ext.get("loading").remove();
                Ext.get("loading-mask").remove();
            }
        },


        // 去掉字符串中的html标签
        stripHtmlTags: function (str) {
            return str.replace(/<[^>]*>/g, "");
        },


        // 弹出Alert对话框
        alert: function (msg, title, icon, okscript) {
            title = title || X.util.alertTitle;
            icon = icon || Ext.MessageBox.INFO;
            Ext.MessageBox.show({
                title: title,
                msg: msg,
                buttons: Ext.MessageBox.OK,
                icon: icon,
                fn: function (buttonId) {
                    if (buttonId === "ok") {
                        if (typeof (okscript) === "function") {
                            okscript.call(window);
                        }
                    }
                }
            });
        },

        // 向页面添加Loading...节点
        appendLoadingNode: function () {
            return X.util.appendFormNode({ tag: "div", cls: "x-ajax-loading", html: X.util.loading });
        },

        // 向页面的 form 节点最后添加新的节点
        appendFormNode: function (htmlOrObj) {
            return Ext.DomHelper.append(document.forms[0], htmlOrObj);
        },

        // 向页面添加一个隐藏字段，如果已经存在则更新值
        setHiddenFieldValue: function (fieldId, fieldValue) {
            var itemNode = Ext.get(fieldId);
            if (!itemNode) {
                // Ext.DomHelper.append 有问题，例如下面这个例子得到的结果是错的；变通一下，先插入节点，在设置节点的值。
                // Ext.DomHelper.append(document.forms[0], { tag: "input", type: "hidden", value: '{"X_Items":[["Value1","选项 1",1],["Value2","选项 2（不可选择）",0],["Value3","选项 3（不可选择）",0],["Value4","选项 4",1],["Value5","选项 5",1],["Value6","选项 6",1],["Value7","选项 7",1],["Value8","选项 8",1],["Value9","选项 9",1]],"SelectedValue":"Value1"}'});
                // 上面的这个字符串，在IETest的IE8模式下会变成：
                // {"DropDownList1":{"X_Items":[["Value1","\u9009\u9879 1",1],["Value2","\u9009\u9879 2\uff08\u4e0d\u53ef\u9009\u62e9\uff09",0],["Value3","\u9009\u9879 3\uff08\u4e0d\u53ef\u9009\u62e9\uff09",0],["Value4","\u9009\u9879 4",1],["Value5","\u9009\u9879 5",1],["Value6","\u9009\u9879 6",1],["Value7","\u9009\u9879 7",1],["Value8","\u9009\u9879 8",1],["Value9","\u9009\u9879 9",1]],"SelectedValue":"Value1"}}

                X.util.appendFormNode({ tag: "input", type: "hidden", id: fieldId, name: fieldId });
                Ext.get(fieldId).dom.value = fieldValue;
            }
            else {
                itemNode.dom.value = fieldValue;
            }
        },

        // 从表单中删除隐藏字段
        removeHiddenField: function (fieldId) {
            var itemNode = Ext.get(fieldId);
            if (itemNode) {
                itemNode.remove();
            }
        },

        // 获取页面中一个隐藏字段的值
        getHiddenFieldValue: function (fieldId) {
            var itemNode = Ext.get(fieldId);
            if (itemNode) {
                return itemNode.getValue();
            }
            return null;
        },

        // 禁用提交按钮（在回发之前禁用以防止重复提交）
        disableSubmitControl: function (controlClientID) {
            X(controlClientID).disable();
            X.util.setHiddenFieldValue('X_TARGET', controlClientID);
        },

        // 启用提交按钮（在回发之后启用提交按钮）
        enableSubmitControl: function (controlClientID) {
            X(controlClientID).enable();
            X.util.setHiddenFieldValue('X_TARGET', '');
        },

        // 更新ViewState的值
        updateViewState: function (newValue, startIndex, gzipped) {
            if(typeof(startIndex) === 'boolean') {
                gzipped = startIndex;
                startIndex = -1;
            }

            var viewStateHiddenFiledID = "__VIEWSTATE";
            if(gzipped)
            {
                viewStateHiddenFiledID = "__VIEWSTATE_GZ";
            }

            var oldValue = X.util.getHiddenFieldValue(viewStateHiddenFiledID);
            if (Ext.type(startIndex) == "number" && startIndex > 0) {
                if (startIndex < oldValue.length) {
                    oldValue = oldValue.substr(0, startIndex);
                }
            } else {
                // Added on 2011-5-2, this is a horrible mistake.
                oldValue = '';
            }
            X.util.setHiddenFieldValue(viewStateHiddenFiledID, oldValue + newValue);
        },

        // 更新EventValidation的值
        updateEventValidation: function (newValue) {
            X.util.setHiddenFieldValue("__EVENTVALIDATION", newValue);
        },

        // 设置页面状态是否改变
        setPageStateChanged: function () {
            var pageState = Ext.get("X_CHANGED");
            if (pageState && pageState.getValue() == "false") {
                pageState.dom.value = "true";
            }
        },

        // 页面状态是否改变
        isPageStateChanged: function () {
            var pageState = Ext.get("X_CHANGED");
            if (pageState && pageState.getValue() == "true") {
                return true;
            }
            return false;
        },


        // 验证多个表单，返回数组[是否验证通过，第一个不通过的表单字段]
        validForms: function (forms, targetName, showBox) {
            var target = X.util.getTargetWindow(targetName);
            var valid = true;
            var firstInvalidField = null;
            for (var i = 0; i < forms.length; i++) {
                var result = X(forms[i]).x_isValid();
                if (!result[0]) {
                    valid = false;
                    if (firstInvalidField == null) {
                        firstInvalidField = result[1];
                    }
                }
            }

            if (!valid) {
                if (showBox) {
                    var alertMsg = String.format(X.util.formAlertMsg, firstInvalidField.fieldLabel);
                    target.X.util.alert(alertMsg, X.util.formAlertTitle, Ext.MessageBox.INFO);
                }
                return false;
            }
            return true;
        },


        // 判断隐藏字段值（数组）是否包含value
        isHiddenFieldContains: function (domId, testValue) {
            testValue += "";
            var domValue = Ext.get(domId).dom.value;
            if (domValue === "") {
                //console.log(domId);
                return false;
            }
            else {
                var sourceArray = domValue.split(",");
                return sourceArray.indexOf(testValue) >= 0 ? true : false;
            }
        },


        // 将一个字符添加到字符列表中，将2添加到[5,3,4]
        addValueToHiddenField: function (domId, addValue) {
            addValue += "";
            var domValue = Ext.get(domId).dom.value;
            if (domValue == "") {
                Ext.get(domId).dom.value = addValue + "";
            }
            else {
                var sourceArray = domValue.split(",");
                if (sourceArray.indexOf(addValue) < 0) {
                    sourceArray.push(addValue);
                    Ext.get(domId).dom.value = sourceArray.join(",");
                }
            }
        },


        // 从字符列表中移除一个字符，将2从dom的值"5,3,4,2"移除
        removeValueFromHiddenField: function (domId, addValue) {
            addValue += "";
            var domValue = Ext.get(domId).dom.value;
            if (domValue != "") {
                var sourceArray = domValue.split(",");
                if (sourceArray.indexOf(addValue) >= 0) {
                    sourceArray = sourceArray.remove(addValue);
                    Ext.get(domId).dom.value = sourceArray.join(",");
                }
            }
        },


        // 取得隐藏字段的值
        getHiddenFieldValue: function (fieldId) {
            var itemNode = Ext.get(fieldId);
            if (!itemNode) {
                return "";
            }
            else {
                return itemNode.dom.value;
            }
        },


        // 取得表单字段的值，日期字段的值类似"2008-07-08"
        getFormFieldValue: function (cmp) {
            if (cmp.getXType() == "datefield") {
                return cmp.value;
            }
            else {
                return cmp.getValue();
            }
        },

        // 由target获取window对象
        getTargetWindow: function (target) {
            var wnd = window;
            if (target === '_self') {
                wnd = window;
            } else if (target === '_parent') {
                wnd = parent;
            } else if (target === '_top') {
                wnd = top;
            }
            return wnd;
        },


        // 预加载图片
        preloadImages: function (images) {
            var imageInstance = [];
            for (var i = 0; i < images.length; i++) {
                imageInstance[i] = new Image();
                imageInstance[i].src = images[i];
            }
        },

        hasCSS: function (id) {
            return !!Ext.get(id);
        },

        addCSS: function (id, content) {

            // 如果此节点已经存在，则先删除此节点
            var node = Ext.get(id);
            if (node) {
                Ext.removeNode(node.dom);
            }

            // Tricks From: http://www.phpied.com/dynamic-script-and-style-elements-in-ie/
            var ss1 = document.createElement("style");
            ss1.setAttribute("type", "text/css");
            ss1.setAttribute("id", id);
            if (ss1.styleSheet) {   // IE
                ss1.styleSheet.cssText = content;
            } else {                // the world
                var tt1 = document.createTextNode(content);
                ss1.appendChild(tt1);
            }
            var hh1 = document.getElementsByTagName("head")[0];
            hh1.appendChild(ss1);
        },

        /*
        // 在启用AJAX的情况下，使所有的Asp.net的提交按钮（type="submit"）不要响应默认的submit行为，而是自定义的AJAX
        makeAspnetSubmitButtonAjax: function (buttonId) {

        // 低版本IE浏览器不允许使用JS修改input标签的type属性，导致此函数无效
        function resetButton(button) {
        button.set({ "type": "button" });
        button.addListener("click", function (event, el) {
        __doPostBack(el.getAttribute("name"), "");
        event.stopEvent();
        });
        }

        if (typeof (buttonId) === "undefined") {
        Ext.each(Ext.DomQuery.select("input[type=submit]"), function (item, index) {
        resetButton(Ext.get(item));
        });
        } else {
        var button = Ext.get(buttonId);
        if (button.getAttribute("type") === "submit") {
        resetButton(button);
        }
        }

        },

        */

        // Whether a object is empty (With no property) or not.
        isObjectEmpty: function (obj) {
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    return false;
                }
            }
            return true;
        },

        // Convert an array to object.
        // ['Text', 'Icon']  -> {'Text':true, 'Icon': true}
        arrayToObject: function (arr) {
            var obj = {};
            Ext.each(arr, function (item, index) {
                obj[item] = true;
            });
            return obj;
        },

        hideScrollbar: function () {
            if (Ext.isIE) {
                window.document.body.scroll = 'no';
            } else {
                window.document.body.style.overflow = 'hidden';
            }
        },


        // 动态添加一个标签页
		// mainTabStrip： 选项卡实例
		// id： 选项卡ID
		// url: 选项卡IFrame地址 
		// text： 选项卡标题
		// icon： 选项卡图标
		// addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
		// refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
        addMainTab: function (mainTabStrip, id, url, text, icon, addTabCallback, refreshWhenExist) {
            var iconId, iconCss, tabId, currentTab, tabConfig;
			
			// 兼容 addMainTab(mainTabStrip, treeNode, addTabCallback, refreshWhenExist) 调用方式
            if (typeof (id) !== 'string') {
				refreshWhenExist = text;
                addTabCallback = url;
                url = id.attributes.href;
                icon = id.attributes.icon;
                text = id.text;

                id = id.id;
            }
			
            //var href = node.attributes.href;
            if (icon) {
                iconId = icon.replace(/\W/ig, '_');
                if (!X.util.hasCSS(iconId)) {
                    iconCss = [];
                    iconCss.push('.');
                    iconCss.push(iconId);
                    iconCss.push('{background-image:url("');
                    iconCss.push(icon);
                    iconCss.push('")}');
                    X.util.addCSS(iconId, iconCss.join(''));
                }
            }
            // 动态添加一个带工具栏的标签页
            //tabId = 'dynamic_added_tab' + id.replace('__', '-');
            currentTab = mainTabStrip.getTab(id);
            if (!currentTab) {
                tabConfig = {
                    'id': id,
                    'url': url,
                    'title': text,
                    'closable': true,
                    'bodyStyle': 'padding:0px;'
                };
                if (icon) {
                    tabConfig['iconCls'] = iconId;
                }
				
                if (addTabCallback) {
                    var addTabCallbackResult = addTabCallback.apply(window, [tabConfig]);
					// 兼容之前的方法，函数返回值如果不为空，则将返回值作为顶部工具条实例
					if(addTabCallbackResult) {
						tabConfig['tbar'] = addTabCallbackResult;
					}
                }
                mainTabStrip.addTab(tabConfig);
            } else {
                mainTabStrip.setActiveTab(currentTab);
				if(refreshWhenExist) {
					var iframeNode = currentTab.body.query('iframe')[0];
					if(iframeNode) {
						iframeNode.contentWindow.location.reload();
					}
				}
				
            }
        },

		// 初始化左侧树（或者手风琴+树）与右侧选项卡控件的交互
		// treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
		// mainTabStrip： 选项卡实例
		// addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
		// updateLocationHash: 切换Tab时，是否更新地址栏Hash值
		// refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
		// refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
        initTreeTabStrip: function (treeMenu, mainTabStrip, addTabCallback, updateLocationHash, refreshWhenExist, refreshWhenTabChange) {
            
            // 注册树的节点点击事件
            function registerTreeClickEvent(treeInstance) {
                treeInstance.on('click', function (node, event) {
                    if (node.isLeaf()) {
                        // 阻止事件传播
                        event.stopEvent();

                        var href = node.attributes.href;

                        if (updateLocationHash) {
                            // 修改地址栏
                            window.location.hash = '#' + href;
                        }

                        // 新增Tab节点
                        X.util.addMainTab(mainTabStrip, node, addTabCallback, refreshWhenExist);
                    }
                });
            }

            // treeMenu可能是Accordion或者Tree
            if (treeMenu.getXType() === 'panel') {
                treeMenu.items.each(function (item) {
                    var tree = item.items.itemAt(0);
                    if (tree && tree.getXType() === 'treepanel') {
                        registerTreeClickEvent(tree);
                    }
                });
            } else if (treeMenu.getXType() === 'treepanel') {
                registerTreeClickEvent(treeMenu);
            }

			// 切换主窗口的Tab
			mainTabStrip.on('tabchange', function (tabStrip, tab) {
				var tabHash = '#' + (tab.url || '');
				
				// 只有当浏览器地址栏的Hash值和将要改变的不一样时，才进行如下两步处理：
				// 1. 更新地址栏Hash值
				// 2. 刷新Tab内的IFrame
				if(tabHash !== window.location.hash) {
					
					if (updateLocationHash) {
						window.location.hash = tabHash;
					}
					
					if(refreshWhenTabChange) {
						var iframeNode = tab.body.query('iframe')[0];
						if(iframeNode) {
							var currentLocationHref = iframeNode.contentWindow.location.href;
							if(/^http(s?):\/\//.test(currentLocationHref)) {
								iframeNode.contentWindow.location.reload();
							}
						}
					}
				}
				
			});
			
			
            // 页面第一次加载时，根据URL地址在主窗口加载页面
            var HASH = window.location.hash.substr(1);
            if (HASH) {
                var FOUND = false;

                function initTreeMenu(treeInstance, node) {
                    var i, currentNode, nodes, node, path;
                    if (!FOUND && node.hasChildNodes()) {
                        nodes = node.childNodes;
                        for (i = 0; i < nodes.length; i++) {
                            currentNode = nodes[i];
                            if (currentNode.isLeaf()) {
                                if (currentNode.attributes.href === HASH) {
                                    path = currentNode.getPath();
                                    treeInstance.expandPath(path); //node.expand();
                                    treeInstance.selectPath(path); // currentNode.select();
                                    X.util.addMainTab(mainTabStrip, currentNode, addTabCallback);
                                    FOUND = true;
                                    return;
                                }
                            } else {
                                arguments.callee(treeInstance, currentNode);
                            }
                        }
                    }
                }

                if (treeMenu.getXType() === 'panel') {
                    treeMenu.items.each(function (item) {
                        var tree = item.items.itemAt(0);
                        if (tree && tree.getXType() === 'treepanel') {
                            initTreeMenu(tree, tree.getRootNode());

                            // 找到树节点
                            if (FOUND) {
                                item.expand();
                                return false;
                            }
                        }
                    });
                } else if (treeMenu.getXType() === 'treepanel') {
                    initTreeMenu(treeMenu, treeMenu.getRootNode());
                }
            }
			
			
			

        },

		// 复选框分组处理
        resolveCheckBoxGroup: function (name, xstateContainer, isradiogroup) {
            var items = [], i, count, xitem, xitemvalue, xitems, xselectedarray, xselected, xchecked, xitemname;

            xitems = xstateContainer.X_Items;
            xselectedarray = xstateContainer.SelectedValueArray;
            xselected = xstateContainer.SelectedValue;

            if (xitems && xitems.length > 0) {
                for (i = 0, count = xitems.length; i < count; i++) {
                    xitem = xitems[i];
                    xitemvalue = xitem[1];
                    xchecked = false;
                    if (!isradiogroup) {
                        // xselectedarray 可能是undefined, [], ["value1", "value2"]
                        if (xselectedarray) {
                            xchecked = (xselectedarray.indexOf(xitemvalue) >= 0) ? true : false;
                        }
                        xitemname = name + '_' + i;
                    } else {
                        xchecked = (xselected === xitemvalue) ? true : false;
                        xitemname = name;
                    }
                    items.push({
                        'inputValue': xitemvalue,
                        'boxLabel': xitem[0],
                        'name': xitemname,
                        'checked': xchecked
                    });
                }
            } else {
                items.push({
                    'inputValue': "tobedeleted",
                    'boxLabel': "&nbsp;",
                    'name': "tobedeleted"
                });
            }

            return items;

        },

        checkGroupLastTime: function (groupName) {
            var checkName = groupName + '_lastupdatetime';
            var checkValue = X.util[checkName];
            X.util[checkName] = new Date();
            if (typeof (checkValue) === 'undefined') {
                return true;
            } else {
                if ((new Date() - checkValue) < 100) {
                    return false;
                } else {
                    return true;
                }
            }
        },
		
		// 对话框图标
		getMessageBoxIcon: function(iconShortName) {
			var icon = Ext.MessageBox.WARNING;
			if(iconShortName === 'info') {
				icon = Ext.MessageBox.INFO;
			} else if(iconShortName === 'warning') {
				icon = Ext.MessageBox.WARNING;
			}  else if(iconShortName === 'question') {
				icon = Ext.MessageBox.QUESTION;
			}  else if(iconShortName === 'error') {
				icon = Ext.MessageBox.ERROR;
			} 
			return icon;
		},
		
		// 确认对话框
		confirm: function(targetName, title, msg, okScript, cancelScript, iconShortName) {
			var wnd = X.util.getTargetWindow(targetName);
			var icon = X.util.getMessageBoxIcon(iconShortName);
			wnd.Ext.MessageBox.show({
				title: title || X.util.confirmTitle,
				msg: msg,
				buttons: Ext.MessageBox.OKCANCEL,
				icon: icon,
				fn: function (btn) {
					if (btn == 'cancel') {
						if(cancelScript) {
							new Function(cancelScript)();
						} else {
							return false;
						}
					} else {
						if(okScript) {
							new Function(okScript)();
						} else {
							return false;
						}
					}
				}
			});
		}


    };




})();﻿
(function () {

    X.ajax = {

        timeoutErrorMsg: "Request timeout, please refresh the page and try again!",
        errorMsg: "Error! {0} ({1})",
        errorWindow: null,

        hookPostBack: function () {
            if (typeof (__doPostBack) != 'undefined') {
                __doPostBack = x__doPostBack;
            }
        }

    };

    function enableAjax() {
        if (typeof (X.control_enable_ajax) === 'undefined') {
            return X.global_enable_ajax;
        }
        return X.control_enable_ajax;
    }

    function enableAjaxLoading() {
        if (typeof (X.control_enable_ajax_loading) === 'undefined') {
            return X.global_enable_ajax_loading;
        }
        return X.control_enable_ajax_loading;
    }

    function ajaxLoadingType() {
        if (typeof (X.control_ajax_loading_type) === 'undefined') {
            return X.global_ajax_loading_type;
        }
        return X.control_ajax_loading_type;
    }


    function x__doPostBack_internal() {
        if (typeof (X.util.beforeAjaxPostBackScript) === 'function') {
            X.util.beforeAjaxPostBackScript();
        }

        // Ext.encode will convert Chinese characters. Ext.encode({a:"你好"}) => '{"a":"\u4f60\u597d"}'
        // We will include the official JSON object from http://json.org/
        // 现在还是用的 Ext.encode，在 IETester的 IE8下 JSON.stringify 生成的中文是\u9009\u9879形式。
        //X.util.setHiddenFieldValue('X_STATE', encodeURIComponent(JSON.stringify(getXState())));

        var xstate = Ext.encode(getXState());
        if (Ext.isIE6 || Ext.isIE7) {
            X.util.setHiddenFieldValue('X_STATE_URI', 'true');
            xstate = encodeURIComponent(xstate);
        } else {
            xstate = Base64.encode(xstate);
        }
        X.util.setHiddenFieldValue('X_STATE', xstate);
        //X.util.setHiddenFieldValue('X_STATE', encodeURIComponent(Ext.encode(getXState())));
        if (!enableAjax()) {
            // 当前请求结束后必须重置 X.control_enable_ajax
            X.control_enable_ajax = undefined;
            X.util.setHiddenFieldValue('X_AJAX', 'false');
            theForm.submit();
        } else {
            // 当前请求结束后必须重置 X.control_enable_ajax
            X.control_enable_ajax = undefined;
            X.util.setHiddenFieldValue('X_AJAX', 'true');
            var url = document.location.href;
            var urlHashIndex = url.indexOf('#');
            if (urlHashIndex >= 0) {
                url = url.substring(0, urlHashIndex);
            }
            Ext.Ajax.request({
                form: theForm.id,
                url: url,
                isUpload: X.form_upload_file,
                //params: serializeForm(theForm) + '&X_AJAX=true',
                success: function (data) {
                    // see: http://extjs.com/forum/showthread.php?t=8129
                    // 如果页面中有FileUpload，responseObj.responseText会包含于 <pre>标签。
                    var scripts = data.responseText;
                    if (scripts) {
                        // 已经经过encodeURIComponent编码了，在ResponseFilter中的Close函数中
                        var prefix = scripts.substr(0, 4);
                        if (prefix.toLowerCase() === '<pre') {
                            //scripts = scripts.substr(5, scripts.length - 11);
                            //scripts = decodeURIComponent(scripts.replace(/<\/?pre>/ig, ''));
                            scripts = scripts.replace(/<\/?pre[^>]*>/ig, '');
                            scripts = decodeURIComponent(scripts);
                        }
                        //eval(scripts);
                        new Function(scripts)();
                    }
                    X.ajaxReady();
                },
                failure: function (data) {
                    var lastDisabledButtonId = X.util.getHiddenFieldValue('X_TARGET');
                    if (lastDisabledButtonId) {
                        X.enable(lastDisabledButtonId);
                    }
                    //X.util.alert(String.format(X.ajax.errorMsg, data.statusText, data.status));
                    createErrorWindow(data);
                },
                callback: function (options, success, response) {
                    // AJAX结束时需要清空此字段，否则下一次的type=submit提交（ASP.NET回发方式之一）会被误认为是AJAX提交
                    X.util.setHiddenFieldValue('X_AJAX', 'false');
                }
            });
        }
    }


    // 如果启用 Ajax，则所有对 __doPostBack 的调用都会到这里来
    function x__doPostBack(eventTarget, eventArgument) {
        // 回发页面之前延时 100 毫秒，确保页面上的操作完成（比如选中复选框的动作）
        window.setTimeout(function () {
            // theForm variable will always exist, because we invoke the GetPostBackEventReference in PageManager.
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                theForm.__EVENTTARGET.value = eventTarget;
                theForm.__EVENTARGUMENT.value = eventArgument;

                x__doPostBack_internal();
            }
        }, 100);
    }


    function writeContentToIFrame(iframe, content) {
        // http://stackoverflow.com/questions/1477547/getelementbyid-contentdocument-error-in-ie
        // contentWindow is always there.
        if (iframe) {
            var doc = iframe.contentWindow.document;
            if (doc) {
                doc.open();
                doc.write(content);
                doc.close();
            }
        }
    }

    // 创建出错窗口
    function createErrorWindow(data) {
        // 如果是请求超时错误，则弹出简单提醒对话框
        if (data.isTimeout) {
            X.util.alert(X.ajax.timeoutErrorMsg);
            return;
        }

        // 如果响应正文为空，则弹出简单提醒对话框
        if (!data.responseText) {
            X.util.alert(String.format(X.ajax.errorMsg, data.statusText, data.status));
            return;
        }

        if (!X.ajax.errorWindow) {
            X.ajax.errorWindow = new Ext.Window({
                id: "FINEUI_ERROR",
                renderTo: window.body,
                width: 550,
                height: 350,
                border: true,
                animCollapse: true,
                collapsible: false,
                collapsed: false,
                closeAction: "hide",
                plain: false,
                modal: true,
                draggable: true,
                minimizable: false,
                minHeight: 100,
                minWidth: 200,
                resizable: true,
                maximizable: true,
                closable: true
            });
        }

        X.ajax.errorWindow.show();
        X.ajax.errorWindow.body.dom.innerHTML = X.wnd.createIFrameHtml('about:blank', 'FINEUI_ERROR');
        X.ajax.errorWindow.setTitle(String.format(X.ajax.errorMsg, data.statusText, data.status));
        writeContentToIFrame(X.ajax.errorWindow.body.query('iframe')[0], data.responseText);
    }

    // Ext.Ajax.serializeForm has a fault. The result will include type="submit" section, which is not always right.
    /*
    function serializeForm(form) {
    var originalStr = Ext.Ajax.serializeForm(form);
    for (var i = 0; i < form.elements.length; i++) {
    el = form.elements[i];
    if (el.type === 'submit') {
    var submitStr = encodeURIComponent(el.name) + '=' + encodeURIComponent(el.value);
    if (originalStr.indexOf(submitStr) == 0) {
    originalStr = originalStr.replace(submitStr, '');
    } else {
    originalStr = originalStr.replace('&' + submitStr, '');
    }
    }
    }
    return originalStr;
    }
    */

    // 序列化表单为 URL 编码字符串，除去 <input type="submit" /> 的按钮
    var extjsSerializeForm = Ext.lib.Ajax.serializeForm;
    Ext.lib.Ajax.serializeForm = function (form) {
        var el, originalStr = extjsSerializeForm(form);
        for (var i = 0; i < form.elements.length; i++) {
            el = form.elements[i];
            if (el.type === 'submit') {
                var submitStr = encodeURIComponent(el.name) + '=' + encodeURIComponent(el.value);
                if (originalStr.indexOf(submitStr) == 0) {
                    originalStr = originalStr.replace(submitStr, '');
                } else {
                    originalStr = originalStr.replace('&' + submitStr, '');
                }
            }
        }
        return originalStr;
    };


    function getXState() {
        var state = {};
        Ext.ComponentMgr.all.each(function (cmp, index) {
            if (cmp.isXType) {
                // x_props store the properties which has been changed on server-side or client-side.
                // Every FineUI control should has this property.
                var xstate = cmp['x_state'];
                if (xstate && Ext.isObject(xstate)) {
                    var cmpState = getXStateViaCmp(cmp, xstate);
                    if (!X.util.isObjectEmpty(cmpState)) {
                        state[cmp.id] = cmpState;
                    }
                }
            }
        });
        return state;
    }

    X.ajax.getXState = getXState;

    function getXStateViaCmp(cmp, xstate) {
        var state = {};

        Ext.apply(state, xstate);

        function saveInHiddenField(property, currentValue) {
            // Save this client-changed property in a form hidden field. 
            X.util.setHiddenFieldValue(cmp.id + '_' + property, currentValue);
        }
        function removeHiddenField(property) {
            X.util.removeHiddenField(cmp.id + '_' + property);
        }

        // 如果存在Gzip压缩的属性，就删除原来的属性
        function resolveGZProperty(property) {
            var gzProperty = property + '_GZ';
            if (state[gzProperty]) {
                delete state[property];
            } else {
                delete state[gzProperty];
            }
        }



        // 有些属性可以在客户端改变，因此需要在每个请求之前计算
        if (cmp.isXType('menucheckitem')) {
            saveInHiddenField('Checked', cmp.checked);
        }

        if (cmp.isXType('panel')) {
            saveInHiddenField('Collapsed', cmp.collapsed);
        }

        if (cmp.isXType('datepicker')) {
            saveInHiddenField('SelectedDate', cmp.getValue().format(cmp.initialConfig.format));
        }

        if (cmp.isXType('button')) {
            if (cmp.initialConfig.enableToggle) {
                saveInHiddenField('Pressed', cmp.pressed);
            }
        }

        if (cmp.isXType('grid')) {

            if (cmp.isXType('editorgrid')) {
                // 可编辑单元格的表格
                // 选中单元格
                saveInHiddenField('SelectedCell', cmp.x_getSelectedCell().join(','));

                // 新增行
                var newAddedRows = cmp.x_getNewAddedRows();
                if (newAddedRows.length > 0) {
                    saveInHiddenField('NewAddedRows', newAddedRows.join(','));
                } else {
                    removeHiddenField('NewAddedRows');
                }

                // 修改的数据
                var modifiedData = cmp.x_getModifiedData();
                if (modifiedData.length > 0) {
                    saveInHiddenField('ModifiedData', Ext.encode(modifiedData));
                } else {
                    removeHiddenField('ModifiedData');
                }

            } else {
                // 普通的表格
                // 选中行索引列表
                saveInHiddenField('SelectedRowIndexArray', cmp.x_getSelectedRows().join(','));
            }

            // 删除的行索引列表
            var deletedRows = cmp.x_getDeletedRows();
            if (deletedRows.length > 0) {
                saveInHiddenField('DeletedRows', deletedRows.join(','));
            } else {
                removeHiddenField('DeletedRows');
            }

            // 隐藏的列索引列表
            var gridHiddenColumns = cmp.x_getHiddenColumns();
            if (gridHiddenColumns.length > 0) {
                saveInHiddenField('HiddenColumnIndexArray', gridHiddenColumns.join(','));
            } else {
                removeHiddenField('HiddenColumnIndexArray');
            }

            // 目前States仅用于CheckBoxField
            var gridStates = cmp.x_getStates();
            if (gridStates.length > 0) {
                saveInHiddenField('States', Ext.encode(gridStates));
            } else {
                removeHiddenField('States');
            }

            // 如果存在 GZIPPED 的属性，就用 GZIPPED 属性
            resolveGZProperty('X_Rows');
        }

        if (cmp.isXType('combo') || cmp.isXType('checkboxgroup') || cmp.isXType('radiogroup')) {

            // 如果存在 GZIPPED 的属性，就用 GZIPPED 属性
            resolveGZProperty('X_Items');
        }

        if (cmp.isXType('field')) {

            // 如果存在 GZIPPED 的属性，就用 GZIPPED 属性
            resolveGZProperty('Text');
        }

        if (cmp.isXType('treepanel')) {
            saveInHiddenField('ExpandedNodes', cmp.x_getExpandedNodes(cmp.getRootNode().childNodes).join(','));
            saveInHiddenField('CheckedNodes', cmp.x_getCheckedNodes().join(','));
            saveInHiddenField('SelectedNodeIDArray', cmp.x_getSelectedNodes().join(','));

            // 如果存在 GZIPPED 的属性，就用 GZIPPED 属性
            resolveGZProperty('X_Nodes');
        }

        if (cmp.isXType('tabpanel')) {
            saveInHiddenField('ActiveTabIndex', cmp.x_getActiveTabIndex());
        }

        if (cmp['x_type']) {
            if (cmp['x_type'] === 'tab') {
                saveInHiddenField('Hidden', cmp.tabEl.style.display === 'none');
            }
        }

        //        if (cmp.isXType('combo')) {
        //            saveInHiddenField('SelectedValue', cmp.getValue());
        //        }

        return state;
    }



    // 显示“正在载入...”的提示信息
    function _showAjaxLoading(ajaxLoadingType) {
        if (_requestCount > 0) {

            if (ajaxLoadingType === "default") {
                X.ajaxLoadingDefault.setStyle('left', (Ext.getBody().getWidth() - X.ajaxLoadingDefault.getWidth()) / 2 + 'px');
                X.ajaxLoadingDefault.show();
            } else {
                X.ajaxLoadingMask.show();
            }

        }
    }

    // 隐藏“正在载入...”的提示信息
    function _hideAjaxLoading(ajaxLoadingType) {
        if (_requestCount <= 0) {
            _requestCount = 0;

            if (ajaxLoadingType === "default") {
                X.ajaxLoadingDefault.hide();
            } else {
                X.ajaxLoadingMask.hide();
            }

        }
    }

    // 当前 Ajax 的并发请求数
    var _requestCount = 0;

    // 发起 Ajax 请求之前事件处理
    Ext.Ajax.on('beforerequest', function (conn, options) {
        _requestCount++;

        if (!enableAjaxLoading()) {
            // Do nothing
        } else {
            Ext.defer(_showAjaxLoading, 100, window, [ajaxLoadingType()]);
        }
    });

    // Ajax 请求结束
    Ext.Ajax.on('requestcomplete', function (conn, options) {
        _requestCount--;

        if (!enableAjaxLoading()) {
            // ...
        } else {
            Ext.defer(_hideAjaxLoading, 100, window, [ajaxLoadingType()]);
        }
        X.control_enable_ajax_loading = undefined;
        X.control_ajax_loading_type = undefined;
    });

    // Ajax 请求发生异常
    Ext.Ajax.on('requestexception', function (conn, options) {
        _requestCount--;

        if (!enableAjaxLoading()) {
            // ...
        } else {
            Ext.defer(_hideAjaxLoading, 100, window, [ajaxLoadingType()]);
        }
        X.control_enable_ajax_loading = undefined;
        X.control_ajax_loading_type = undefined;
    });






    //        // 不适用于所有Extjs控件（比如Toolbar中放置按钮，这个按钮就没有ownerCt对象）
    //        // 更新一个Javascript对象
    //        updateObject: function(obj, newObjFunction, renderImmediately) {
    //            var id = obj.id;
    //            if (Ext.type(renderImmediately) == 'boolean' && !renderImmediately) {

    //                // 1.取得父容器
    //                var owner = obj.ownerCt;
    //                // 2.本控件在父容器的位置
    //                var insertIndex = owner.items.indexOf(obj);
    //                // 3.从父容器中销毁此控件
    //                owner.remove(obj);
    //                // 4.创建新的控件
    //                newObjFunction();
    //                // 5.将新的控件添加到删除的位置
    //                owner.insert(insertIndex, Ext.getCmp(id));
    //                // 6.父容器重新布局
    //                owner.doLayout();

    //            }
    //            else {

    //                // 1.销毁此控件
    //                obj.destroy();
    //                // 2.新建此控件
    //                newObjFunction();
    //            }
    //        }

})();﻿

(function () {

    // 计算黄金分割点的位置
    // bodySize : 整个页面的Body的大小 
    // windowSize : 窗口的大小
    function _calculateGoldenPosition(bodySize, windowSize) {
        var top = (bodySize.height - (bodySize.height / 1.618)) - windowSize.height / 2;
        if (top < 0) {
            top = 0;
        }
        var left = (bodySize.width - windowSize.width) / 2;
        if (left < 0) {
            left = 0;
        }
        return { left: left, top: top };
    }

    // 计算中间的位置
    // bodySize : 整个页面的Body的大小 
    // windowSize : 窗口的大小
    function _calculateCenterPosition(bodySize, windowSize) {
        var top = (bodySize.height - windowSize.height) / 2;
        if (top < 0) {
            top = 0;
        }
        var left = (bodySize.width - windowSize.width) / 2;
        if (left < 0) {
            left = 0;
        }
        return { left: left, top: top };
    }



    // 创建IFrame节点片段
    function _createIFrameHtml(iframeUrl, iframeName) {
        return '<iframe frameborder="0" style="overflow:auto;height:100%;width:100%;" name="' + iframeName + '" src="' + iframeUrl + '"></iframe>';
    }

    // 获取窗体的外部容器
    function _getWrapperNode(panel) {
        return Ext.get(panel.el.findParentNode('.x-window-wrapper'));
    }

    // FineUI窗口域（Window）
    X.wnd = {

        closeButtonTooltip: "Close this window",
        formModifiedConfirmTitle: "Close Confrim",
        formModifiedConfirmMsg: "Current form has been modified.<br/><br/>Abandon changes?",

        createIFrameHtml: function (iframeUrl, iframeName) {
            return _createIFrameHtml(iframeUrl, iframeName);
        },

        // 显示一个弹出窗体
        // 在 panel 实例中，定义了几个自定义属性，用于标示此实例的状态（在PanelBase中定义）
        // 属性 - x_iframe/x_iframe_url/x_iframe_name/x_iframe_loaded
        // panel : 当前弹出的窗体（Ext-Window）
        // iframeUrl : 弹出窗体中包含的IFrame的地址
        // windowTitle : 弹出窗体的标题
        // left/top : 弹出窗体的左上角坐标（如果为空字符串，则使用中间位置或黄金分隔位置）
        // isGoldenSection : 弹出窗体位于页面的黄金分隔位置
        // hiddenHiddenFieldID : 在页面中放置表单字段记录此窗体是否弹出，也页面回发时保持状态用
        show: function (panel, iframeUrl, windowTitle, left, top, isGoldenSection, hiddenHiddenFieldID) {
            var target = X.util.getTargetWindow(panel['x_property_target']);
            var guid = panel['x_property_guid'];
            if (window.frameElement && target !== window) {
                // 当前页面在IFrame中（也即时 window.frameElement 存在）
                // 此弹出窗体需要在父窗口中弹出
                if (!target.X[guid]) {
                    // 父窗口中已经创建了这个Ext-Window对象
                    var wrapper = guid + '_wrapper';
                    if (!target.Ext.get(wrapper)) {
                        target.X.util.appendFormNode('<div class="x-window-wrapper" id="' + wrapper + '"></div>');
                    } else {
                        target.Ext.get(wrapper).dom.innerHTML = '';
                    }
                    // Ext.apply 的第三个参数是default obejct
                    var config = Ext.apply({}, {
                        'renderTo': wrapper,
                        'manager': target.X.window_default_group,
                        'id': guid,
                        //'box_hide': null,
                        //'box_hide_refresh': null,
                        //'box_hide_postback': null,
                        // 'x_show': null,
                        // 在 X.wnd.getActiveWindow 中需要用到这个参数
                        //'box_property_frame_element_name': window.frameElement.name,
                        //'box_property_client_id': panel.getId(),
                        'x_property_window': window,
                        'x_property_ext_window': panel
                    }, panel.initialConfig);

                    // 在父页面中创建一个Ext-Window的幻影（拷贝）
                    // 在这个幻影中，通过“x_property_frame_element_name”属性标示这是一个幻影
                    // x_property_frame_element_name: 并且真正的Ext-Window在当前页面中的哪个IFrame中
                    // x_property_client_id: 并且真正的Ext-Window在所在页面中的客户端ID
                    target.X[guid] = new target.Ext.Window(config);
                }
                panel = target.X[guid];
            }
            if (iframeUrl !== '') {
                X.wnd.updateIFrameNode(panel, iframeUrl);
            }
            if (windowTitle != '') {
                panel.setTitle(windowTitle);
            }

            var bodySize = target.window.Ext.getBody().getViewSize();

            //            // Update container's width and height
            //            var wrapperNode = _getWrapperNode(panel);
            //            wrapperNode.setWidth(bodySize.width).setHeight(bodySize.height);
            //            
            //            // 显示窗体之前，记着显示外部的容器
            //            wrapperNode.show();

            Ext.get(hiddenHiddenFieldID).dom.value = 'false';
            panel.show();

            if (left !== '' && top !== '') {
                panel.setPosition(parseInt(left, 10), parseInt(top, 10));
            } else {
                var panelSize = panel.getSize(), leftTop;
                if (isGoldenSection) {
                    leftTop = _calculateGoldenPosition(bodySize, panelSize);
                } else {
                    leftTop = _calculateCenterPosition(bodySize, panelSize);
                    //panel.alignTo(target.Ext.getBody(), "c-c");
                }
                panel.setPosition(leftTop.left, leftTop.top);
            }

            if (panel.maximizable) {
                X.wnd.fixMaximize(panel);


                // 改变浏览器大小可以自动调整窗体控件的大小（窗体控件最大化时）
                target.Ext.EventManager.onWindowResize(function () {
                    X.wnd.fixMaximize(panel);
                });

            }
        },

        // 获取真正的Window实例
        getRealWindow: function (panel, targetName, guid) {
            var target = X.util.getTargetWindow(targetName);
            if (window.frameElement && target !== window) {
                // 从父页面中查找幻影Ext-Window对象
                panel = target.X[guid];
            }
            return panel;
        },

        // 隐藏Ext-Window（比如用户点击了关闭按钮）
        hide: function (panel, targetName, enableIFrame, hiddenHiddenFieldID, guid) {
            var wnd = X.wnd.getRealWindow(panel, targetName, guid);
            // 修改当前页面中记录弹出窗口弹出状态的隐藏表单字段
            Ext.get(hiddenHiddenFieldID).dom.value = 'true';
            // 如果启用IFrame，则清空IFrame的内容，防止下次打开时显示残影
            if (enableIFrame) {
                wnd.body.first().dom.src = 'about:blank';
                wnd['x_iframe_url'] = 'about:blank';
            }
            wnd.hide();
        },

        // 最大化
        maximize: function (panel, targetName, guid) {
            var wnd = X.wnd.getRealWindow(panel, targetName, guid);
            wnd.maximize();
        },

        // 最小化
        minimize: function (panel, targetName, guid) {
            var wnd = X.wnd.getRealWindow(panel, targetName, guid);
            wnd.minimize();
        },

        // 恢复窗体大小
        restore: function (panel, targetName, guid) {
            var wnd = X.wnd.getRealWindow(panel, targetName, guid);
            wnd.restore();
        },

        // 这是 Extjs 的一个 bug，如果 Window 控件不是渲染在 document.body 中，则 maximize 函数并不能真正的最大化
        // 现在的 Window 控件时渲染在 from 表单里面的一个 DIV 中的
        fixMaximize: function (panel) {
            if (panel.maximized) {
                var target = X.util.getTargetWindow(panel['x_property_target']);
                var bodySize = target.window.Ext.getBody().getViewSize();
                panel.setSize(bodySize.width, bodySize.height);
                // 不要忘记左上角坐标
                panel.setPosition(0, 0);
            }
        },

        // 创建或更新IFrame节点，同时更新panel实例中的自定义属性值
        updateIFrameNode: function (panel, iframeUrl) {
            var iframeUrlChanged = false;
            // 如果此Panel中包含有IFrame
            if (panel && panel['x_iframe']) {
                if (iframeUrl && panel['x_iframe_url'] !== iframeUrl) {
                    panel['x_iframe_url'] = iframeUrl;
                    iframeUrlChanged = true;
                }
                // 如果此Panel中包含的IFrame还没有加载
                if (!panel['x_iframe_loaded']) {
                    window.setTimeout(function () {
                        // 如果此Panel已经创建完毕，但有时Panel可能是延迟创建的（比如TabStrip中的Tab，只有点击这个Tab时才创建Tab的内容）
                        if (panel.body) {
                            panel['x_iframe_loaded'] = true;
                            panel.body.dom.innerHTML = _createIFrameHtml(panel['x_iframe_url'], panel['x_iframe_name']);
                        }
                    }, 0);
                }
                else {
                    if (iframeUrlChanged) {
                        panel.body.first().dom.src = panel['x_iframe_url'];
                    }
                }
            }
        },


        // 处理表单中有任何字段发生变化时，关闭当前窗口时的提示
        confirmFormModified: function (closeFn) {
            if (X.util.isPageStateChanged()) {
                Ext.MessageBox.show({
                    title: X.wnd.formModifiedConfirmTitle,
                    msg: X.wnd.formModifiedConfirmMsg,
                    buttons: Ext.MessageBox.OKCANCEL,
                    icon: 'ext-mb-warning',
                    fn: function (btn) {
                        if (btn == 'cancel') {
                            return false;
                        } else {
                            closeFn.apply(window, arguments);
                        }
                    }
                });
            } else {
                closeFn.apply(window, arguments);
            }
        },


        // Ext-Window中IFrame里页面中的表单发生变化时弹出确认消息
        extWindowIFrameFormModifiedConfirm: function (panel, closeFn) {
            // 这个页面所在的Window对象
            var pageWindow = X.wnd.getIFrameWindowObject(panel);
            // 如果弹出的页面没能正常加载（比如说网络暂时连接中断）
            // 则直接关闭弹出的Ext-Window，而不会去检查页面表单变化，因为页面对象不存在
            if (pageWindow.X) {
                pageWindow.X.wnd.confirmFormModified(closeFn);
            }
            else {
                panel.x_hide();
            }
        },

        // 取得panel的Iframe节点的window对象（可以是幻影Ext-Window中的页面window对象）
        getIFrameWindowObject: function (panel) {
            // 当前页面在IFrame中（也即时 window.frameElement 存在）
            // 此Ext-Window需要在父窗口中弹出
            if (window.frameElement && panel['x_property_show_in_parent']) {
                panel = parent.X[panel['x_property_guid']];
            }
            var iframeNode = Ext.query('iframe', panel.body.dom);
            if (iframeNode.length === 0) {
                // 当前panel（Ext-Window）不包含iframe
                return window;
            }
            else {
                return iframeNode[0].contentWindow;
            }
        },


        // 这是老方法，虽然也能正常工作，但是绕了一个弯 => 在幻影ExtWindow中保存当前IFrame的parent.window以及iframe name。
        // 其实没必要，直接在幻影ExtWindow中保存真实的ExtWindow对象即可（只不过这个对象可能是在其他页面中）。
        // 取得当前页面所在的Ext-Window实际的对象，返回[实际的Ext-Window对象，实际的Ext-Window对象所在的window对象]
        // 注意
        // 1. 如果是在当前页面弹出窗口的话，“实际的Ext-Window对象”存在于父页面（parent.box）中
        // 2. 如果是在父页面弹出窗口的话，“实际的Ext-Window对象”存在于父页面（parent）下面的IFrame页面中
        // 3. 通过判断当前的Ext-Window是否存在“box_property_frame_element_name”属性，可知当前的Ext-Window是否幻影（即时实际Ext-Window对象在父页面的一个拷贝），在X.wnd.show中设置的属性
        /*
        getActiveWindow: function () {
        var activeWindow = parent.window;
        var activeExtWindow = parent.X.window_default_group.getActive();
        if (activeExtWindow['box_property_frame_element_name']) {
        var iframeParentWindow = activeExtWindow['box_property_parent_window'];
        activeWindow = iframeParentWindow.Ext.query('iframe[name=' + activeExtWindow['box_property_frame_element_name'] + ']')[0].contentWindow;
        activeExtWindow = activeWindow.Ext.getCmp(activeExtWindow['box_property_client_id']);
        }

        return [activeExtWindow, activeWindow];
        },
        */

        getActiveWindow: function () {
            var activeWindow = parent.window;
            var activeExtWindow = parent.X.window_default_group.getActive();
            if (activeExtWindow['x_property_window']) {
                activeWindow = activeExtWindow['x_property_window'];
                activeExtWindow = activeExtWindow['x_property_ext_window'];
            }

            return [activeExtWindow, activeWindow];
        },


        //    // 从url中提取box_parent_client_id参数的值
        //    window.box_getParentClientIdFromUrl = function() {
        //        var result = '';
        //        var url = window.location.href;
        //        var startIndex = url.indexOf('box_parent_client_id');
        //        if (startIndex >= 0) {
        //            result = url.substr(startIndex + 'box_parent_client_id'.length + 1);
        //        }

        //        return result;
        //    };

        //    // 取得当前页面所在窗口，返回数组[当前窗口对象，当前窗口所在的window对象]
        //    window.box_getActiveWindow = function() {
        //        var aw = null;
        //        var window2 = null;

        //        var parentClientID = box_getParentClientIdFromUrl();
        //        if (parentClientID) {
        //            window2 = parent.window;
        //            aw = parent.window.Ext.getCmp(parentClientID);
        //            if (aw.box_property_frame_element_name) {
        //                window2 = parent.Ext.query('iframe[name=' + aw.box_property_frame_element_name + ']')[0].contentWindow;
        //                aw = eval('window2.X.' + aw.id);
        //            }
        //        }

        //        if (aw) {
        //            return [aw, window2];
        //        }
        //        else {
        //            return null;
        //        }
        //    };

        // 向弹出此Ext-Window的页面写入值
        writeBackValue: function () {
            var aw = X.wnd.getActiveWindow();
            var controlIds = aw[0]['x_property_save_state_control_client_ids'];
            var controlCount = Math.min(controlIds.length, arguments.length);
            for (var i = 0; i < controlCount; i++) {
                aw[1].Ext.getCmp(controlIds[i]).setValue(arguments[i]);
            }
            //        var controlClientIds = (function() {
            //            if (aw) {
            //                return eval('aw[1].X.' + aw[0].id + '.box_string_state');
            //            }
            //        })();
            //        if (typeof (controlClientIds) == 'string') {
            //            aw[1].Ext.getCmp(controlClientIds).setValue("哈哈");
            //        } else {
            //            aw[1].Ext.getCmp(controlClientIds[0]).setValue("哈哈");
            //            var controlValues = ['哈哈 的值', '哈哈 的值2'];
            //            var controlCount = Math.min(controlClientIds.length - 1, controlValues.length);
            //            for (var i = 0; i < controlCount; i++) {
            //                aw[1].Ext.getCmp(controlClientIds[i + 1]).setValue(controlValues[i]);
            //            }
            //        }
            //        var aw = X.wnd.getActiveWindow();
            //        if (aw) {
            //            aw[0].box_hide();
            //        }
        }

    };

})();
﻿
Ext.override(Ext.Component, {

    x_setDisabled: function () {
        this.setDisabled(!this.x_state['Enabled']);
    },

    x_setVisible: function () {
        this.setVisible(!this.x_state['Hidden']);
    }

});

// 验证一个表单是否有效，会递归查询表单中每个字段
// 如果表单隐藏或者字段隐藏，则不进行有效性校验
Ext.override(Ext.Panel, {
    x_isValid: function () {
        var valid = true;
        var firstInvalidField = null;
        if (!this.hidden) {
            this.items.each(function (f) {
                if (!f.hidden) {
                    if (f.isXType('field')) {
                        if (!f.validate()) {
                            valid = false;
                            if (firstInvalidField == null) {
                                firstInvalidField = f;
                            }
                        }
                    } else if (f.items) {
                        var validResult = f.x_isValid();
                        if (!validResult[0]) {
                            valid = false;
                            if (firstInvalidField == null) {
                                firstInvalidField = validResult[1];
                            }
                        }
                    }
                }
            });
        }
        return [valid, firstInvalidField];
    },

    x_reset: function () {
        this.items.each(function (f) {
            if (f.isXType('field')) {
                f.reset();
            } else if (f.items) {
                validResult = this.x_reset();
            }
        });
    },


    x_setCollapse: function () {
        var collapsed = this.x_state['Collapsed'];
        if (collapsed) {
            this.collapse(true);
        }
        else {
            this.expand(true);
        }
    },

    x_setTitle: function () {
        this.setTitle(this.x_state['Title']);
    }


});

/*
Ext.override(Ext.form.field.HtmlEditor, {

//  Add functionality to Field's initComponent to enable the change event to bubble
initComponent: Ext.Function.createSequence(Ext.form.field.Base.prototype.initComponent, function () {
this.enableBubble('change');
}),

x_setValue: function () {
this.setValue(this.x_state['Text']);
}

});
*/

if (Ext.form.Field) {
    Ext.override(Ext.form.Field, {

        //  Add functionality to Field's initComponent to enable the change event to bubble
        initComponent: Ext.form.Field.prototype.initComponent.createSequence(function () {
            this.enableBubble('change');
        }),

        /* 这会导致在文本输入框中按回车键，无法触发type=submit的表单回发事件
        listeners: {
        specialkey: function (field, e) {
        if (e.getKey() == e.ENTER) {
        e.stopEvent();
        }
        }
        },
        */

        /*
        // When show or hide the field, also hide the label.
        hide: function () {
        Ext.form.Field.superclass.hide.call(this);
        //this.callOverridden();

        //var label = Ext.get(this.el.findParent('div[class=x-form-item]')).first('label[for=' + this.id + ']');
        var labelAndField = this.el.findParentNode('div[class*=x-form-item]', 10, true);
        if (labelAndField) {
        if (this.hideMode == 'display') {
        labelAndField.setVisibilityMode(Ext.Element.DISPLAY);
        } else {
        labelAndField.setVisibilityMode(Ext.Element.VISIBILITY);
        }
        labelAndField.hide();
        }
        },

        show: function () {
        Ext.form.Field.superclass.show.call(this);
        //this.callOverridden();

        //var label = Ext.get(this.el.findParent('div[class=x-form-item]')).first('label[for=' + this.id + ']');
        var labelAndField = this.el.findParentNode('div[class*=x-form-item]', 10, true);
        if (labelAndField) {
        if (this.hideMode == 'display') {
        labelAndField.setVisibilityMode(Ext.Element.DISPLAY);
        } else {
        labelAndField.setVisibilityMode(Ext.Element.VISIBILITY);
        }
        labelAndField.show();
        }
        },
        */

        x_setValue: function (text) {
            text = text || this.x_state['Text'];
            this.setValue(text);
        },

        x_setLabel: function (text) {
            if (this.label && this.label.update) {
                this.label.update(text || this.x_state['Label']);
            }
        }

    });
}

if (Ext.menu.CheckItem) {
    Ext.override(Ext.menu.CheckItem, {

        x_setChecked: function () {
            this.setChecked(this.x_state['Checked'], true);
        }

    });
}

if (Ext.form.Checkbox) {
    Ext.override(Ext.form.Checkbox, {

        x_setValue: function () {
            this.setValue(this.x_state['Checked']);
        }

    });
}

if (Ext.form.Radio) {
    Ext.override(Ext.form.Radio, {

        x_setValue: function () {
            this.setValue(this.x_state['Checked']);
        }

    });
}


if (Ext.form.RadioGroup) {
    Ext.override(Ext.form.RadioGroup, {

        // 单选框列表的getValue函数，ExtJS没有实现
        // Extjs3.4已经有相应的实现了
        /*
        getValue: function () {
        var value = null;
        Ext.each(this.items.items, function (item, index) {
        if (item.checked) {
        value = item.inputValue;
        }
        });
        return value;
        }
        */

        x_setValue: function (value) {
            if (typeof (value) === 'undefined') {
                value = this.x_state['SelectedValue'];
            }
            this.setValue(value);
        }

    });
}


if (Ext.form.CheckboxGroup) {
    Ext.override(Ext.form.CheckboxGroup, {

        x_reloadData: function (name, isradiogroup) {
            var container = this.ownerCt;
            var newConfig = Ext.apply(this.initialConfig, {
                "x_state": this.x_state,
                "items": X.util.resolveCheckBoxGroup(name, this.x_state, isradiogroup)
            });

            if (container) {
                var originalIndex = container.items.indexOf(this);
                container.remove(this, true);

                if (isradiogroup) {
                    container.insert(originalIndex, new Ext.form.RadioGroup(newConfig));
                } else {
                    container.insert(originalIndex, new Ext.form.CheckboxGroup(newConfig));
                }
                container.doLayout();
            } else {
                this.destroy();
                if (isradiogroup) {
                    new Ext.form.RadioGroup(newConfig);
                } else {
                    new Ext.form.CheckboxGroup(newConfig);
                }

            }
        },

        x_toBeDeleted: function () {
            var tobedeleted = this.items.items[0];
            if (tobedeleted && tobedeleted.inputValue === 'tobedeleted') {
                tobedeleted.destroy();
                this.items.remove(tobedeleted);
            }
        },

        x_setValue: function (value) {
            var valueArray = value || this.x_state['SelectedValueArray'];
            // 此时value的值类似于：["value1", "value2", "value3"]

            var selectedArray = [];
            this.eachItem(function (item) {
                if (valueArray.indexOf(item.getRawValue()) === -1) {
                    selectedArray.push(false);
                } else {
                    selectedArray.push(true);
                }
            });

            this.setValue(selectedArray);

            /* 
            var result = {}, i, currentSelectedCheckboxs;
            currentSelectedCheckboxs = this.getValue();
            for (i = 0; i < currentSelectedCheckboxs.length; i++) {
            result[currentSelectedCheckboxs[i].getRawValue()] = false;
            }

            for (i = 0; i < valueArray.length; i++) {
            result[valueArray[i]] = true;
            }
            this.setValue(result);
            */
        }

    });
}

if (Ext.form.ComboBox) {
    Ext.override(Ext.form.ComboBox, {
        // Load data from local cache.
        //        mode: "local",
        //        triggerAction: "all",
        displayField: "text",
        valueField: "value",
        //tpl: "<tpl for=\".\"><div class=\"x-combo-list-item <tpl if=\"!enabled\">x-combo-list-item-disable</tpl>\">{prefix}{text}</div></tpl>",

        // These variables are in the Ext.form.ComboBox.prototype, therefore all instance will refer to the same store instance.
        //store: new Ext.data.ArrayStore({ fields: ['value', 'text', 'enabled', 'prefix'] }),

        x_setValue: function (value) {
            // value 可以是空字符串
            if (typeof (value) === 'undefined') {
                value = this.x_state['SelectedValue'];
            }
            this.setValue(value);
        },

        x_loadData: function (data) {
            data = data || this.x_state['X_Items'];
            if (data) {
                this.store.loadData(X.simulateTree.transform(data));
            }
        },


        x_getTextByValue: function (value, data) {
            data = data || this.x_state['X_Items'];
            value += ''; // 把Value转换为字符串
            for (var i = 0, count = data.length; i < count; i++) {
                var item = data[i];
                if (item[0] === value) {
                    return item[1];
                }
            }
            return '';
        }

    });
}


if (Ext.Button) {
    Ext.override(Ext.Button, {

        x_setTooltip: function () {
            this.setTooltip(this.x_state['ToolTip']);
        },

        x_toggle: function () {
            this.toggle(this.x_state['Pressed']);
        },

        x_setText: function () {
            this.setText(this.x_state['Text']);
        }


    });
}


if (Ext.grid.RowNumberer) {

    X.originalRowNumbererRenderer = Ext.grid.RowNumberer.prototype.renderer;
    Ext.override(Ext.grid.RowNumberer, {

        renderer: function (v, p, record, rowIndex) {

            var number = X.originalRowNumbererRenderer.call(this, v, p, record, rowIndex);

            if (this.x_paging_enabled && this.x_paging) {
                number += this.x_paging.pageIndex * this.x_paging.pageSize;
            }

            return number;
        }

    });

}

if (Ext.data.Store) {
    Ext.override(Ext.data.Store, {
        // true to clear all modified record information each time the store is loaded or when a record is removed (defaults to false).
        pruneModifiedRecords: true

    });
}

if (Ext.grid.GridPanel) {
    Ext.override(Ext.grid.GridPanel, {

        x_getData: function () {
            var $this = this, data = this.x_state['X_Rows']['Values'];

            //////////////////////////////////////////////////
            var tpls = this.x_tpls;
            //if (!tpls) {
            if (typeof (tpls) === 'undefined') {
                tpls = this.x_getTpls();
            }

            // 将Grid1_ctl37与对应的outHTML放在哈希表中
            var tplsHash = {};
            var e = document.createElement('div');
            e.innerHTML = tpls;
            Ext.each(e.childNodes, function (item, index) {
                tplsHash[item.id] = item.outerHTML.replace(/\r?\n\s*/ig, '');
            });

            // INPUT:  /(<div id="(.+)_container">)<\/div>/ig.exec("<div id=\"Grid1_ctl37_container\"></div>")
            // OUTPUT: ["<div id="Grid1_ctl37_container"></div>", "<div id="Grid1_ctl37_container">", "Grid1_ctl37"]
            /*
            Ext.each(data, function (row, rowIndex) {
            Ext.each(row, function (item, index) {
            if (item.substr(0, 7) === "#@TPL@#") {
            var clientId = item.substr(7);
            row[index] = '<div id="' + clientId + '_container">' + tplsHash[clientId] + '</div>';
            }
            });
            });
            */

            // 不要改变 X_Rows -> Values 的原始数据，因为这个值会被POST到后台
            var newdata = [], newdataitem;
            Ext.each(data, function (row, rowIndex) {
                newdataitem = [];
                Ext.each(row, function (item, index) {
                    if (item.substr(0, 7) === "#@TPL@#") {
                        var clientId = $this.id + '_' + item.substr(7);
                        newdataitem.push('<div id="' + clientId + '_container">' + tplsHash[clientId] + '</div>');
                    } else {
                        newdataitem.push(item);
                    }
                });
                newdata.push(newdataitem);
            });
            //////////////////////////////////////////////////

            return newdata;
        },

        x_getTpls: function () {
            var tpls, tplsNode = Ext.get(this.id + '_tpls');
            if (tplsNode) {
                tpls = tplsNode.dom.innerHTML;

                // 获取模板列的内容之后，必须要删除原有的节点，因为会在表格中创建完全相同的新节点
                tplsNode.remove();

                // 将模板列内容保存到表格实例中
                this['data-last-tpls'] = tpls;

            } else {

                tpls = this['data-last-tpls'];
            }

            return tpls;
        },


        x_updateTpls: function (tpls) {
            if (typeof (tpls) == 'undefined') {
                tpls = this.x_getTpls();
            }

            var e = document.createElement('div');
            e.innerHTML = tpls;
            Ext.each(e.childNodes, function (item, index) {
                var nodeId = item.id;
                Ext.get(nodeId + '_container').dom.innerHTML = item.outerHTML;
            });
        },


        x_loadData: function () {
            var datas = this.x_getData();
            var pagingBar = this.getBottomToolbar();
            if (pagingBar) {
                var pagingDatas = [];
                if (pagingBar.x_databasePaging) {
                    pagingDatas = datas;
                } else {
                    for (var i = pagingBar.x_startRowIndex; i <= pagingBar.x_endRowIndex; i++) {
                        pagingDatas.push(datas[i]);
                    }
                }
                datas = pagingDatas;
            }


            var store = this.getStore();

            // 已经设置 Ext.data.Store 的 pruneModifiedRecords ，在重新加载数据时都会清除所有已经改变的数据
            // 所以无需 rejectChanges
            // 拒绝之前对表格的编辑，因为接下来就要重新加载数据
            //store.rejectChanges();

            // 重新加载数据前清空之前的改变
            //this.x_newAddedRows = [];
            //this.x_deletedRows = [];

            store.loadData(datas);


            this.x_initRecordIDs();

        },

        // 初始化所有记录的ID列表
        x_initRecordIDs: function () {
            var $this = this;
            this.x_recordIDs = [];
            this.getStore().each(function (record, index) {
                $this.x_recordIDs.push(record.id);
            });
        },

        // 展开所有的行扩展列
        x_expandAllRows: function () {
            if (this.plugins && this.plugins[0] && this.plugins[0].id === 'expander') {
                for (var i = 0, count = this.store.getCount(); i < count; i++) {
                    this.plugins[0].expandRow(i);
                }
            }
        },

        // 隐藏所有的行扩展列
        x_collapseAllRows: function () {
            if (this.plugins && this.plugins[0] && this.plugins[0].id === 'expander') {
                for (var i = 0, count = this.store.getCount(); i < count; i++) {
                    this.plugins[0].collapseRow(i);
                }
            }
        },

        // http://evilcroco.name/2010/10/making-extjs-grid-content-selectable/
        // IE下允许选中表格中的文本
        x_enableTextSelection: function () {
            //if (Ext.isIE) {
            var elems = Ext.DomQuery.select("div[unselectable=on]", this.el.dom);
            for (var i = 0, len = elems.length; i < len; i++) {
                Ext.get(elems[i]).set({ 'unselectable': 'off' }).removeClass('x-unselectable');
            }
            //}
        },


        // 获取选中的行数，或者单元格数（单元格编辑模式）
        x_getSelectedCount: function () {
            var selectedCount = 0;
            var sm = this.getSelectionModel();
            if (sm.hasSelection()) {
                if (sm.getCount) {
                    selectedCount = sm.getCount();
                } else {
                    // 单元格编辑模式，只可能选中一个单元格
                    selectedCount = 1;
                }
            }
            return selectedCount;
        },

        // 选中某些行
        x_selectRows: function (rows) {
            rows = rows || this.x_state['SelectedRowIndexArray'] || [];
            var sm = this.getSelectionModel();
            if (sm.selectRows) {
                sm.selectRows(rows);
            }
        },

        // 获取选中的行
        x_getSelectedRows: function () {
            var selectedRows = [];
            var sm = this.getSelectionModel();
            if (sm.getSelections) {
                var selections = sm.getSelections();
                var store = this.getStore();

                Ext.each(selections, function (record, index) {
                    selectedRows.push(store.indexOfId(record.id));
                });
            }

            return selectedRows;
        },


        // 选中单元格（AllowCellEditing）
        x_selectCell: function (cell) {
            cell = cell || this.x_state['SelectedCell'] || [];
            var sm = this.getSelectionModel();
            if (sm.select) {
                if (cell.length === 2) {
                    sm.select(cell[0], cell[1]);
                } else {
                    sm.clearSelections();
                }
            }
        },

        // 获取选中的单元格（AllowCellEditing）
        x_getSelectedCell: function () {
            var selectedCell = [];
            var sm = this.getSelectionModel();
            if (sm.getSelectedCell) {
                selectedCell = sm.getSelectedCell();
                if (!selectedCell) {
                    selectedCell = [];
                }
            }
            return selectedCell;
        },



        // 获取隐藏列的索引列表
        x_getHiddenColumns: function () {
            var hiddens = [], model = this.getColumnModel(), columns = model.config;
            Ext.each(columns, function (column, index) {
                if (model.isHidden(index)) {
                    hiddens.push(index);
                }
            });
            return hiddens;
        },

        // 隐藏需要隐藏的列，显示不需要隐藏的列
        x_updateColumnsHiddenStatus: function (hiddens) {
            hiddens = hiddens || this.x_state['HiddenColumnIndexArray'] || [];
            var model = this.getColumnModel(), columns = model.config;
            Ext.each(columns, function (column, index) {
                if (hiddens.indexOf(index) !== -1) {
                    model.setHidden(index, true);
                } else {
                    model.setHidden(index, false);
                }
            });
        },

        // 设置表格标题栏的排序图标 .x-grid3-hd-over
        x_setSortIcon: function (sortColumnIndex, sortDirection) {
            var gridEl = Ext.get(this.id), columns = this.x_getColumns();

            function getHeaderNode(index) {
                if (typeof (index) === 'number') {
                    return gridEl.select('.x-grid3-hd-row .x-grid3-cell.x-grid3-td-' + columns[index].id);
                } else {
                    return gridEl.select('.x-grid3-hd-row .x-grid3-cell.x-grid3-hd');
                }
            }

            // Clear sort icon for all column header.
            getHeaderNode().removeClass(['sort-asc', 'sort-desc']);

            // Add cursor to all server sortable column header.
            Ext.each(columns, function (item, index) {
                if (item['sortable']) {
                    getHeaderNode(index).addClass('cursor-pointer');
                }
            });

            // Set current sort column
            if (sortColumnIndex >= 0 && sortColumnIndex < columns.length) {
                getHeaderNode(sortColumnIndex).addClass('sort-' + sortDirection.toLowerCase());
            }

        },

        // 获取表格列
        x_getColumns: function () {
            var columns = [];
            // this.getColumnModel().config -> An Array of Column definition objects representing the configuration of this ColumnModel.
            var configColumns = this.getColumnModel().config;
            Ext.each(configColumns, function (item, index) {
                // expander也属于表格列的一种类型，否则设置x_setSortIcon会出错
                if (item.id !== 'numberer' && item.id !== 'checker') { // && item.id !== 'expander'
                    columns.push(item);
                }
            });
            return columns;
        },

        // 这个方法用不到了，现在对States的更新会导致Values的改变，进而促使表格的重新加载
        /*
        x_setRowStates: function (states) {
        var gridEl = Ext.get(this.id), columns = this.x_getColumns(), states = states || this.x_state['X_States'] || [];

        function setCheckBoxStates(columnIndex, stateColumnIndex) {
        var checkboxRows = gridEl.select('.x-grid3-body .x-grid3-row .x-grid3-td-' + columns[columnIndex].id + ' .box-grid-checkbox');
        checkboxRows.each(function (row, rows, index) {
        if (states[index][stateColumnIndex]) {
        if (row.hasClass('box-grid-checkbox-unchecked-disabled')) {
        row.removeClass('box-grid-checkbox-unchecked-disabled');
        } else {
        row.removeClass('box-grid-checkbox-unchecked');
        }
        } else {
        if (row.hasClass('box-grid-checkbox-disabled')) {
        row.addClass('box-grid-checkbox-unchecked-disabled')
        } else {
        row.addClass('box-grid-checkbox-unchecked')
        }
        }
        });
        }

        var stateColumnIndex = 0;
        Ext.each(columns, function (column, index) {
        if (column['x_persistState']) {
        if (column['x_persistStateType'] === 'checkbox') {
        setCheckBoxStates(index, stateColumnIndex);
        stateColumnIndex++;
        }
        }
        });
        },
        */

        // 获取列状态（目前只有CheckBoxField用到）
        x_getStates: function () {
            var gridEl = Ext.get(this.id), columns = this.x_getColumns(), states = [];

            function getCheckBoxStates(columnIndex) {
                var checkboxRows = gridEl.select('.x-grid3-row .x-grid3-td-' + columns[columnIndex].id + ' .box-grid-checkbox');
                var columnStates = [];
                checkboxRows.each(function (row, index) {
                    if (row.hasClass('unchecked')) {
                        columnStates.push(false);
                    } else {
                        columnStates.push(true);
                    }
                });
                return columnStates;
            }

            Ext.each(columns, function (column, index) {
                if (column['x_persistState']) {
                    if (column['x_persistStateType'] === 'checkbox') {
                        states.push(getCheckBoxStates(index));
                    }
                }
            });

            // 把列状态列表转换为行状态列表，与后台数据保持一致
            var i, resolvedStates = [], rowState, rowCount;
            if (states.length > 0) {
                rowCount = states[0].length;
                for (i = 0; i < rowCount; i++) {
                    rowState = [];
                    Ext.each(states, function (state, index) {
                        rowState.push(state[i]);
                    });
                    resolvedStates.push(rowState);
                }
            }

            return resolvedStates;
        },

        // 提交客户端改变
        x_commitChanges: function () {

            this.getStore().commitChanges();

            //this.x_newAddedRows = [];
            //this.x_deletedRows = [];
            this.x_initRecordIDs();
        },

        // 从Store中删除选中的行（或者单元格）
        x_deleteSelected: function () {
            var $this = this;
            var store = this.getStore();

            var sm = this.getSelectionModel();
            if (sm.getSelections) {
                var selections = sm.getSelections();
                Ext.each(selections, function (record, index) {
                    store.remove(record);
                });
            } else if (sm.getSelectedCell) {
                var selectedCell = sm.getSelectedCell();
                store.removeAt(selectedCell[0]);
            }
        },

        // 添加一条新纪录
        x_addNewRecord: function (defaultObj, appendToEnd) {
            var i, count, store = this.getStore();
            var recordType = store.recordType;
            var newRecord = new recordType(defaultObj);

            this.stopEditing();
            if (appendToEnd) {
                store.add(newRecord);

                // 新增客户端改变的行索引
                //this.x_newAddedRows.push(store.getCount() - 1);

            } else {
                store.insert(0, newRecord);

                // 新增客户端改变的行索引
                //for (i = 0, count = this.x_newAddedRows.length; i < count; i++) {
                //    this.x_newAddedRows[i]++;
                //}
                //this.x_newAddedRows.push(0);

            }
            this.startEditing(0, 0);
        },

        // 获取新增的行索引（在修改后的列表中）
        x_getNewAddedRows: function () {
            var $this = this;
            var newAddedRows = [];
            this.getStore().each(function (record, index) {
                if ($this.x_recordIDs.indexOf(record.id) < 0) {
                    newAddedRows.push(index);
                }
            });
            return newAddedRows;
        },

        // 获取删除的行索引（在原始的列表中）
        x_getDeletedRows: function () {
            var currentRecordIDs = [], deletedRows = [];
            this.getStore().each(function (record, index) {
                currentRecordIDs.push(record.id);
            });

            // 快速判断是否存在行被删除的情况
            if (currentRecordIDs.join('') === this.x_recordIDs.join('')) {
                return deletedRows;
            }

            Ext.each(this.x_recordIDs, function (recordID, index) {
                if (currentRecordIDs.indexOf(recordID) < 0) {
                    deletedRows.push(index);
                }
            });
            return deletedRows;
        },

        // 获取用户修改的单元格值
        x_getModifiedData: function () {
            var i, j, count, columns = this.x_getColumns(), columnMap = {};

            Ext.each(columns, function (column, index) {
                columnMap[column.id] = column;
            });

            function checkColumnEditable(columnID) {
                var column = columnMap[columnID];
                if (column && (column.editor || column.xtype === 'checkcolumn')) {
                    return true;
                }
                return false;
            }

            var modifiedRows = [];
            var store = this.getStore();
            var modifiedRecords = store.getModifiedRecords();
            var rowIndex, rowData, newData, modifiedRecord, recordID, rowIndexOriginal;
            for (i = 0, count = modifiedRecords.length; i < count; i++) {
                modifiedRecord = modifiedRecords[i];
                recordID = modifiedRecord.id;
                rowIndex = store.indexOf(modifiedRecord);
                rowData = modifiedRecord.data;
                if (rowIndex < 0) {
                    continue;
                }

                // 本行数据在原始数据集合中的行索引
                rowIndexOriginal = this.x_recordIDs.indexOf(recordID);
                if (rowIndexOriginal < 0) {
                    // 删除那些不能编辑的列
                    for (var columnID in rowData) {
                        if (!checkColumnEditable(columnID)) {
                            delete rowData[columnID];
                        }
                    }
                    // 新增数据行
                    modifiedRows.push([rowIndex, -1, rowData]);
                } else {
                    var rowModifiedObj = {};
                    for (var columnID in modifiedRecord.modified) {
                        if (checkColumnEditable(columnID)) {
                            newData = rowData[columnID];
                            rowModifiedObj[columnID] = newData;
                        }
                    }
                    // 修改现有数据行
                    modifiedRows.push([rowIndex, rowIndexOriginal, rowModifiedObj]);
                }

            }

            // 结果按照 rowIndex 升序排序
            return modifiedRows.sort(function (a, b) { return a[0] - b[0]; });
        }

    });
}


if (Ext.tree.TreePanel) {
    Ext.override(Ext.tree.TreePanel, {

        x_loadData: function () {
            var datas = this.x_state['X_Nodes'];
            var nodes = this.x_tranformData(datas);
            var root = this.getRootNode();
            if (root) {
                root.removeAll();
            }
            this.setRootNode(new Ext.tree.AsyncTreeNode({
                id: this.id + '_root',
                children: nodes
            }));
        },

        x_tranformData: function (datas) {
            var that = this, i = 0, nodes = [];
            for (i = 0; i < datas.length; i++) {
                var data = datas[i], node = {};

                //            function copyIfExists(prop) {
                //                if (typeof (data[prop]) !== 'undefined') {
                //                    node[prop] = data[prop];
                //                }
                //            }

                // 0 - Text
                // 1 - Leaf
                // 2 - NodeID
                // 3 - Enabled
                // 4 - EnableCheckBox
                // 5 - Checked
                // 6 - Expanded
                // 7 - NavigateUrl
                // 8 - Target
                // 9 - href
                // 10 - Icon
                // 11 - IconUrl
                // 12 - iconUrl
                // 13 - ToolTip
                // 14 - SingleClickExpand
                // 15 - OnClientClick
                // 16 - EnablePostBack
                // 17 - AutoPostBack
                // 18 - CommandName
                // 19 - CommandArgument
                // 20 - Nodes
                node.text = data[0];
                node.leaf = !!data[1];
                node.id = data[2];
                node.disabled = !data[3];
                if (!!data[4]) {
                    node.checked = !!data[5];
                }
                if (!data[1]) {
                    node.expanded = !!data[6];
                }
                if (data[9]) {
                    node.href = data[9];
                    node.hrefTarget = data[8];
                }
                if (data[12]) {
                    node.icon = data[12];
                }
                node.qtip = data[13];
                node.singleClickExpand = !!data[14];


                node.listeners = {};

                if (!data[3]) {
                    node.listeners.beforeclick = function () {
                        return false;
                    };
                }

                if (!!data[4] && !!data[17]) {
                    node.listeners.checkchange = function (node, checked) {
                        var args = 'Check$' + node.id + '$' + checked;
                        __doPostBack(that.name, args);
                    };
                }

                var clickScript = '';
                if (data[15]) {
                    clickScript += data[15] + ';';
                }
                if (!!data[16]) {
                    clickScript += "__doPostBack('" + that.name + "', 'Command$" + node.id + "$" + data[18] + "$" + data[19] + "');";
                }
                if (clickScript) {
                    node.listeners.click = new Function('node', clickScript);
                }


                if (data[20] && data[20].length > 0) {
                    node.children = that.x_tranformData(data[20]);
                }

                nodes.push(node);
            }
            return nodes;
        },

        x_getExpandedNodes: function (nodes) {
            var i = 0, that = this, expandedNodes = [];

            for (; i < nodes.length; i++) {
                var node = nodes[i];
                if (node.isExpanded()) {
                    expandedNodes.push(node.id);
                }
                if (node.hasChildNodes()) {
                    expandedNodes = expandedNodes.concat(that.x_getExpandedNodes(node.childNodes));
                }
            }

            return expandedNodes;
        },

        x_getCheckedNodes: function () {
            return this.getChecked('id');
        },

        x_getSelectedNodes: function () {
            var model = this.getSelectionModel(), nodes = [];
            if (model.constructor === Ext.tree.MultiSelectionModel) {
                Ext.each(model.getSelectedNodes(), function (item, index) {
                    nodes.push(item.id);
                });
            } else {
                var selectedNode = model.getSelectedNode();
                if (selectedNode) {
                    nodes.push(selectedNode.id);
                }
            }
            return nodes;
        },

        x_selectNodes: function () {
            var datas = this.x_state['SelectedNodeIDArray'] || [];
            var model = this.getSelectionModel(), i = 0;
            for (i = 0; i < datas.length; i++) {
                model.select(this.getNodeById(datas[i]), null, true);
            }
        }


    });
}


if (Ext.PagingToolbar) {
    // We don't use this Class in current version.
    Ext.override(Ext.PagingToolbar, {

        x_hideRefresh: function () {
            var index = this.items.indexOf(this.refresh);
            this.items.get(index - 1).hide();
            this.refresh.hide();
        }

    });
}


if (Ext.TabPanel) {
    Ext.override(Ext.TabPanel, {

        x_autoPostBackTabsContains: function (tabId) {
            var tabs = this.x_state['X_AutoPostBackTabs'];
            return tabs.indexOf(tabId) !== -1;
        },

        x_setActiveTab: function () {
            var tabIndex = this.x_state['ActiveTabIndex'];
            this.setActiveTab(tabIndex);
        },

        x_getActiveTabIndex: function () {
            return this.items.indexOf(this.getActiveTab());
        },

        /*
        // private
        onBeforeShowItem: function (item) {
        this.showTab(item);
        if (item != this.activeTab) {
        this.setActiveTab(item);
        return false;
        }
        },
        // private
        onStripMouseDown: function (e) {
        if (e.button !== 0) {
        return;
        }
        e.preventDefault();
        var t = this.findTargets(e);
        if (t.close) {
        if (t.item['x_dynamic_added_tab']) {
        if (t.item.fireEvent('beforeclose', t.item) !== false) {
        t.item.fireEvent('close', t.item);
        this.remove(t.item);
        }
        } else {
        this.hideTab(t.item);
        }
        return;
        }
        if (t.item && t.item != this.activeTab) {
        this.setActiveTab(t.item);
        }
        },
        */


        activateNextTab: function (c) {
            if (c == this.activeTab) {
                var next = this.stack.next();
                if (next) {
                    this.setActiveTab(next);
                }
                if (next = this.items.find(function (t) { return t.tabEl.style.display !== 'none'; })) {
                    // Find the first visible tab and set it active tab. 
                    this.setActiveTab(next);
                } else {
                    this.setActiveTab(null);
                }
            }
        },

        hideTab: function (item) {
            item = this.getComponent(item);
            this.hideTabStripItem(item);
            item.hide();
            this.activateNextTab(item);
        },

        showTab: function (item) {
            item = this.getComponent(item);
            this.unhideTabStripItem(item);
        },


        addTab: function (id, url, title, closable) {
            var options = {};
            if (typeof (id) === 'string') {
                Ext.apply(options, {
                    'id': id,
                    'title': title,
                    'closable': closable,
                    'url': url
                });
            } else {
                // id is not a string, then there should be only one argument.
                Ext.apply(options, id);
            }
            Ext.apply(options, {
                'x_dynamic_added_tab': true,
                'html': '<iframe id="' + options.id + '" name="' + options.id + '" src="' + options.url + '" frameborder="0" style="height:100%;width:100%;overflow:auto;"\></iframe\>'
            });
            var tab = this.add(options);
            this.activate(tab);

            return tab;
        },

        getTab: function (id) {
            return this.getItem(id);
        },

        removeTab: function (id) {
            this.remove(id);
        }

    });
}




if (Ext.Window) {

    Ext.override(Ext.Window, {

        // 此函数为了兼容考虑，请使用 x_hide 函数
        box_hide: function () {
            this.x_hide();
        },
        box_hide_refresh: function () {
            this.x_hide_refresh();
        },
        box_hide_postback: function (argument) {
            this.x_hide_postback(argument);
        },
        box_show: function (iframeUrl, windowTitle) {
            this.x_show(iframeUrl, windowTitle);
        },


        x_hide: function () {
            X.wnd.hide(this, this.x_property_target, this.x_iframe, this.id + '_Hidden', this.x_property_guid);
        },
        x_hide_refresh: function () {
            this.x_hide();
            window.location.reload();
        },
        x_hide_postback: function (argument) {
            // 如果argument为undefined，则传入__doPostBack应为空字符串
            argument = argument || '';
            this.x_hide();
            __doPostBack(this.name, argument);
        },
        x_show: function (iframeUrl, windowTitle) {
            X.wnd.show(this, iframeUrl, windowTitle, this.x_property_left, this.x_property_top, this.x_property_position, this.id + '_Hidden');
        },

        x_maximize: function () {
            X.wnd.maximize(this, this.x_property_target, this.x_property_guid);
        },
        x_minimize: function () {
            X.wnd.minimize(this, this.x_property_target, this.x_property_guid);
        },
        x_restore: function () {
            X.wnd.restore(this, this.x_property_target, this.x_property_guid);
        }

    });
}


if (Ext.dd.DragDrop) {
    // 修正IE7下，窗口出现滚动条时，点击Window控件标题栏有时node为null的问题
    X.originalIsValidHandleChild = Ext.dd.DragDrop.prototype.isValidHandleChild;
    Ext.dd.DragDrop.prototype.isValidHandleChild = function (node) {
        if (!node || !node.nodeName) {
            return false;
        }
        return X.originalIsValidHandleChild.apply(this, [node]);
    };
}

if (Ext.grid.GridPanel) {
    // 修正在IE下，Grid的模版列中出现文本输入框或者下拉列表时，第一次不能选中的问题
    // 已经有网友发现这个问题：http://www.sencha.com/forum/archive/index.php/t-49653.html
    // This is what caused my self-rendered-Html-Elements to "flicker" as described in my other thread. 
    // The Dropdown receives the Click, opens and stays open for the Millisecond until
    // Ext calls back and gives focus to the Cell, causing my Drop-Down to close again.
    Ext.grid.GridView.prototype.focusCell = function (row, col, hscroll) {
        this.syncFocusEl(this.ensureVisible(row, col, hscroll));

        var focusEl = this.focusEl;

        focusEl.focus();
    };
}


if (Ext.ux.grid && Ext.ux.grid.ColumnHeaderGroup) {
    // 修正Chrome下多表头样式错位
    // 增加 !Ext.isChrome 的判断，在Chrome下DIV的宽度不包括边框的宽度
    Ext.ux.grid.ColumnHeaderGroup.prototype.getGroupStyle = function (group, gcol) {
        var width = 0, hidden = true;
        for (var i = gcol, len = gcol + group.colspan; i < len; i++) {
            if (!this.cm.isHidden(i)) {
                var cw = this.cm.getColumnWidth(i);
                if (typeof cw == 'number') {
                    width += cw;
                }
                hidden = false;
            }
        }
        return {
            width: (Ext.isBorderBox || (Ext.isWebKit && !Ext.isSafari2 && !Ext.isChrome) ? width : Math.max(width - this.borderWidth, 0)) + 'px',
            hidden: hidden
        };
    };

}




// 修正IE7/IE8下Date.parse('2015-10-01')出错的问题
(function () {

    // http://jibbering.com/faq/#parseDate
    function parseISO8601(dateStr) {
        var isoExp = /(\d{2,4})-(\d\d?)-(\d\d?)/,
       date = new Date(NaN), month,
       parts = isoExp.exec(dateStr);

        if (parts) {
            month = +parts[2];
            date.setFullYear(parts[1], month - 1, parts[3]);
            if (month != date.getMonth() + 1) {
                date.setTime(NaN);
            }
        }
        return date;
    }

	var originalParse = Date.parse;
    Date.parse = function (dateStr) {
        var date = originalParse(dateStr);
        if (isNaN(date)) {
            date = parseISO8601(dateStr);
        }
        return date;
    }

})();

﻿
(function() {

    function getParentIndex(levels, level, index) {
        if (level > 0) {
            for (var i = index - 1; i >= 0; i--) {
                if (levels[i] == level - 1) {
                    return i;
                }
            }
        }
        return -1;
    }

    function hasLittleBrother(levels, level, index) {
        if (index < levels.length - 1) {
            for (var i = index + 1; i < levels.length; i++) {
                if (levels[i] == level) {
                    return true;
                } else if (levels[i] < level) {
                    return false;
                }
            }
        }
        return false;
    }

    function getParentTempData(tempdatas, tempdata, prefixIndex) {
        for (var i = 0; i < prefixIndex - 1; i++) {
            tempdata = tempdatas[tempdata.parentIndex];
        }
        return tempdata;
    }

    function getPrefixInner(tempdatas, tempdata, prefixIndex) {
        // If level = 3, then prefixIndex array will be: [3, 2, 1]
        // prefixIndex === 1 will always present the nearest prefix next to the Text.
        if (prefixIndex === 1) {
            if (tempdata.littleBrother) {
                return '<div class="x-elbow"></div>';
            }
            else {
                return '<div class="x-elbow-end"></div>';
            }
        } else {
            var parentdata = getParentTempData(tempdatas, tempdata, prefixIndex);
            if (parentdata.littleBrother) {
                return '<div class="x-elbow-line"></div>';
            }
            else {
                return '<div class="x-elbow-empty"></div>';
            }
        }
        return "";
    }

    function getPrefix(tempdatas, index) {
        var tempdata = tempdatas[index];
        var level = tempdata.level;
        var prefix = [];
        for (var i = level; i > 0; i--) {
            prefix.push(getPrefixInner(tempdatas, tempdata, i));
        }
        return prefix.join('');
    }

    X.simulateTree = {

        transform: function(datas) {
            if (!datas.length || datas[0].length < 4) {
                return datas;
            }

            //// store: new Ext.data.ArrayStore({ fields: ['value', 'text', 'enabled', 'prefix'] })
            //// Sample data:      
            //[
            //    ["0", "jQuery", 0, 0],
            //    ["1", "Core", 0, 1],
            //    ["2", "Selectors", 0, 1],
            //    ["3", "Basic Filters", 1, 2],
            //    ["4", "Content Filters", 1, 2],
            //    ["41", "Contains", 1, 3],
            //    ["5", "Attribute Filters", 1, 2],
            //    ["6", "Traversing", 1, 1],
            //    ["7", "Filtering", 1, 2],
            //    ["8", "Finding", 1, 2],
            //    ["9", "Events", 0, 1],
            //    ["10", "Page Load", 1, 2],
            //    ["11", "Event Handling", 1, 2],
            //    ["12", "Interaction Helpers", 1, 2],
            //    ["13", "Ajax", 1, 1]
            //]
            var levels = [];
            Ext.each(datas, function(data, index) {
                levels.push(data[3]);
            });

            var tempdatas = [];
            Ext.each(levels, function(level, index) {
                tempdatas.push({
                    'level': level,
                    'parentIndex': getParentIndex(levels, level, index),
                    'littleBrother': hasLittleBrother(levels, level, index)
                });
            });

            var newdatas = [];
            Ext.each(datas, function(data, index) {
                newdatas.push([data[0], data[1], data[2], getPrefix(tempdatas, index)]);
            });
            return newdatas;

        }


    };

})();﻿
(function () {

    var F = Ext.util.Format;

    X.format = {

        capitalize: F.capitalize,

        date: F.dateRenderer,

        ellipsis: function (length) {
            return function (value) {
                return F.ellipsis(value, length, false);
            };
        },

        fileSize: F.fileSize,

        htmlEncode: F.htmlEncode,

        htmlDecode: F.htmlDecode,

        lowercase: F.lowercase,

        uppercase: F.uppercase,

        nl2br: F.nl2br,

        number: F.numberRenderer,

        stripScripts: F.stripScripts,

        stripTags: F.stripTags,

        trim: F.trim,

        usMoney: F.usMoney



    };


})();