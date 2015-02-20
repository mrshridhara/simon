(function () {
    'use strict';

    var files = {
        css: {
            destPath: './Core/Simon.UI.Web/Content/',
            src: [
                './Core/Simon.UI.Web/Content/bootstrap.css',
                './Core/Simon.UI.Web/Content/site-tweaks.css'
            ],
            dest: 'app.css'
        },
        js: {
            destPath: './Core/Simon.UI.Web/',
            lib: {
                src: [
                    './Core/Simon.UI.Web/Scripts/jquery-2.1.3.js',
                    './Core/Simon.UI.Web/Scripts/bootstrap.js',
                    './Core/Simon.UI.Web/Scripts/angular.js',
                    './Core/Simon.UI.Web/Scripts/angular-route.js'
                ],
                dest: 'scripts.js'
            },
            app: {
                src: [
                    './Core/Simon.UI.Web/App/**/*.js'
                ],
                dest: 'app.js'
            }
        }
    },
        gulp = require('gulp'),
        concat = require('gulp-concat'),
        uglify = require('gulp-uglify'),
        sourcemaps = require('gulp-sourcemaps'),
        ngAnnotate = require('gulp-ng-annotate'),
        minifyCSS = require('gulp-minify-css'),
        jshint = require('gulp-jshint');

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

    gulp.task('default', [
        'lint',
        'bundle-js-app'
    ]);

    gulp.task('bundle-all', [
        'bundle-css',
        'bundle-js-lib',
        'default'
    ]);
}());