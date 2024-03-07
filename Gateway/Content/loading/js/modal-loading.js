(function (window, $, factory) { window.Loading = factory(window, $) })(window, jQuery, function (window, $) {
    var windowWidth; var windowHeight; function Loading(options) { return new Loading.prototype._init($('body'), options) }
    const init = Loading.prototype._init = function ($target, options) { this.version = '1.0.0'; this.$target = $target; this.set = $.extend(!0, {}, this.set, options); this._build(); return this }; Loading.prototype._build = function () {
        this.$modalMask = $('<div class="modal-mask"></div>'); this.$modalLoading = $('<div class="modal-loading"></div>'); this.$loadingTitle = $('<p class="loading-title"></p>'); this.$loadingAnimation = $('<div class="loading-animate"></div>'); this.$animationOrigin = $('<div class="animate-origin"><span></span></div>'); this.$animationImage = $('<img/>'); this.$loadingDiscription = $('<p class="loading-discription"></p>'); if (this.set.zIndex <= 0) { this.set.zIndex = (this.$target.siblings().length - 1 || this.$target.children().siblings().length) + 10001 }
        this._buildMask(); this._buildLoading(); this._buildTitle(); this._buildLoadingAnimation(); this._buildDiscription(); this._init = !1; if (this.set.defaultApply) { this.apply() }
    }
    Loading.prototype._buildMask = function () {
        if (!this.set.mask) { this.$modalMask.css({ position: 'absolute', top: '-200%', }); return }
        this.$modalMask.css({ backgroundColor: this.set.maskBgColor, zIndex: this.set.zIndex, }); this.$modalMask.addClass(this.set.maskClassName)
    }
    Loading.prototype._buildLoading = function () {
        this.$modalLoading.css({ width: this.set.loadingWidth, height: this.set.loadingHeight, padding: this.set.loadingPadding, backgroundColor: this.set.loadingBgColor, borderRadius: this.set.loadingBorderRadius, }); if (this.set.direction === 'hor') { this.$modalLoading.addClass('modal-hor-layout') }
        this.$modalMask.append(this.$modalLoading)
    }
    Loading.prototype._buildTitle = function () {
        if (!this.set.title) { return }
        this.$loadingTitle.css({ color: this.set.titleColor, fontSize: this.set.titleFontSize, }); this.$loadingTitle.addClass(this.set.titleClassName); this.$loadingTitle.text(this.set.title); this.$modalLoading.append(this.$loadingTitle)
    }
    Loading.prototype._buildLoadingAnimation = function () {
        this.$loadingAnimation.css({ width: this.set.animationWidth, height: this.set.animationHeight, }); if (this.set.loadingAnimation === 'origin') { this.$animationOrigin.children().css({ width: this.set.animationOriginWidth, height: this.set.animationOriginHeight, backgroundColor: this.set.animationOriginColor, }); for (var i = 0; i < 5; i++) { this.$loadingAnimation.append(this.$animationOrigin.clone()) } } else if (this.set.loadingAnimation === 'image') { this.$animationImage.attr('src', this.set.animationSrc); this.$loadingAnimation.append(this.$animationImage) }
        this.$loadingAnimation.addClass(this.set.animationClassName); this.$modalLoading.append(this.$loadingAnimation)
    }
    Loading.prototype._buildDiscription = function () {
        if (!this.set.discription) { return }
        this.$loadingDiscription.css({ color: this.set.discriptionColor, fontSize: this.set.discriptionFontSize, }); this.$loadingDiscription.addClass(this.set.discriptionClassName); this.$loadingDiscription.text(this.set.discription); this.$modalLoading.append(this.$loadingDiscription)
    }
    Loading.prototype._position = function () { windowWidth = $(window).width(); windowHeight = $(window).height(); var loadingWidth = this.$modalLoading.outerWidth(); var loadingHeight = this.$modalLoading.outerHeight(); var x1 = windowWidth >>> 1; var x2 = loadingWidth >>> 1; var left = x1 - x2; var y1 = windowHeight >>> 1; var y2 = loadingHeight >>> 1; var top = y1 - y2; this.$modalLoading.css({ top, left }) }
    Loading.prototype._transitionAnimationIn = function () { if (!this.set.animationIn) { this.$modalMask.css({ display: 'block' }) } else { this.$modalMask.addClass(this.set.animationIn) } }
    Loading.prototype._transitionAnimationOut = function () { if (!this.set.animationOut) { this.$modalMask.remove() } else { this._timer && this._timer.clearTimeout(this._timer); this.$modalMask.removeClass(this.set.animationIn).addClass(this.set.animationOut); var self = this; this._timer = setTimeout(function () { self.$modalMask.remove() }, this.set.animationDuration) } }
    Loading.prototype.apply = function () { this._transitionAnimationIn(); if (!this._init) { this._initLoading() } }
    Loading.prototype.out = function () { this._transitionAnimationOut() }
    Loading.prototype._initLoading = function () {
        if (this._init) { return }
        this.$target.append(this.$modalMask); this._position(); var self = this; $(window).resize(function () { windowWidth = $(window).width(); windowHeight = $(window).height(); self._position() }); this._init = !0
    }
    Loading.prototype.set = { direction: 'ver', title: undefined, titleColor: '#FFF', titleFontSize: 14, titleClassName: undefined, discription: undefined, discriptionColor: '#FFF', discriptionFontSize: 14, discriptionClassName: undefined, loadingWidth: 'auto', loadingHeight: 'auto', loadingPadding: 20, loadingBgColor: '#252525', loadingBorderRadius: 12, mask: !0, maskBgColor: 'rgba(0, 0, 0, .6)', maskClassName: undefined, loadingAnimation: 'origin', animationSrc: undefined, animationWidth: 40, animationHeight: 40, animationOriginWidth: 4, animationOriginHeight: 4, animationOriginColor: '#FFF', animationClassName: undefined, defaultApply: !0, animationIn: 'animated fadeIn', animationOut: 'animated fadeOut', animationDuration: 1000, zIndex: 0, }; init.prototype = Loading.prototype; return Loading
})