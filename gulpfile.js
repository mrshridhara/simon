(function () {
    'use strict';

    var files = {
        css: {
            destPath: './Simon/Simon.UI.Web/Content/',
            src: [
                './Simon/Simon.UI.Web/Content/bootstrap.css',
                './Simon/Simon.UI.Web/Content/bootstrap-theme.css',
                './Simon/Simon.UI.Web/Content/site-tweaks.css'
            ],
            dest:'app.css'
        },
        js: {
            destPath: './Simon/Simon.UI.Web/',
            lib: {
                src: [
                    './Simon/Simon.UI.Web/Scripts/jquery-2.1.1.js',
                    './Simon/Simon.UI.Web/Scripts/bootstrap.js',
                    './Simon/Simon.UI.Web/Scripts/angular.js',
                    './Simon/Simon.UI.Web/Scripts/angular-route.js'
                ],
                dest: 'scripts.js'
            },
            app: {
                src: [
                    './Simon/Simon.UI.Web/App/**/*.js'
                ],
                dest: 'app.js'
            }
        }
    };

    var gulp = require('gulp');
    var concat = require('gulp-concat');
    var uglify = require('gulp-uglify');
    var sourcemaps = require('gulp-sourcemaps');
    var ngAnnotate = require('gulp-ng-annotate');
    var minifyCSS = require('gulp-minify-css');
    var gutil = require('gulp-util');
    var jshint = require('gulp-jshint');

    gulp.task('lint', function () {
        return gulp.src(files.js.app.src)
          .pipe(jshint())
          .pipe(jshint.reporter('default'));
    });

    gulp.task('bundle-css', function () {
        return gulp.src(files.css.src)
            .pipe(sourcemaps.init())
            .pipe(concat(files.css.dest))
            .pipe(minifyCSS({ keepBreaks: true }))
            .pipe(sourcemaps.write())
            .pipe(gulp.dest(files.css.destPath));
    });

    gulp.task('bundle-js-lib', function () {
        return gulp.src(files.js.lib.src)
            .pipe(sourcemaps.init())
            .pipe(concat(files.js.lib.dest))
            .pipe(uglify())
            .pipe(sourcemaps.write())
            .pipe(gulp.dest(files.js.destPath));
    });

    gulp.task('bundle-js-app', function () {
        return gulp.src(files.js.app.src)
            .pipe(sourcemaps.init())
            .pipe(ngAnnotate({
                add: true,
                single_quotes: true
            }))
            .pipe(concat(files.js.app.dest))
            .pipe(uglify())
            .pipe(sourcemaps.write())
            .pipe(gulp.dest(files.js.destPath));
    });

    gulp.task('bundle-all', [
        'bundle-css',
        'bundle-js-lib',
        'bundle-js-app'
    ]);

    gulp.task('default', [
        'lint',
        'bundle-js-app'
    ]);
})();