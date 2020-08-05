addpath(genpath('/import/c4dm-scratch/davidr/BayesianMixing'))
load('RedToBlueDrumsNormalised.mat');
 
Qs = [1 0.6 0.3 0.2 0.2 1];
FREQs = [75 100 250 750 2500 7500];

eqGainUB = zeros(size(AudioData, 2) * 6 , 1);
eqGainUB(1:(size(AudioData, 2) * 6 )) = 6;

eqGainLB = zeros(size(AudioData, 2) * 6, 1);
eqGainLB(1:(size(AudioData, 2) * 6)) = -6;

ratioUB = zeros(size(AudioData, 2), 1);
ratioUB(1:(size(AudioData, 2))) = 6;

ratioLB = zeros(size(AudioData, 2), 1);
ratioLB(1:(size(AudioData, 2))) = 1.0;

thresholdUB = zeros(size(AudioData, 2), 1);
thresholdUB(1:(size(AudioData, 2))) = 0;

thresholdLB = zeros(size(AudioData, 2), 1);
thresholdLB(1:(size(AudioData, 2))) = -30;

tauAttackUB = zeros(size(AudioData, 2), 1);
tauAttackUB(1:(size(AudioData, 2))) = 0.25;

tauAttackLB = zeros(size(AudioData, 2), 1);
tauAttackLB(1:(size(AudioData, 2))) = 0.005;

tauReleaseUB = zeros(size(AudioData, 2), 1);
tauReleaseUB(1:(size(AudioData, 2))) = 3.0;

tauReleaseLB = zeros(size(AudioData, 2), 1);
tauReleaseLB(1:(size(AudioData, 2))) = 0.005;

xUB = [eqGainUB; ratioUB; thresholdUB; tauAttackUB; tauReleaseUB];
xLB = [eqGainLB; ratioLB; thresholdLB; tauAttackLB; tauReleaseLB];

options = optimoptions('particleswarm', 'Display', 'iter', 'UseParallel', true, 'FunctionTolerance', 0.05, 'ObjectiveLimit', 0);

fun = @(x)MaskingMinimisationFunctionNegativeSMR(x, AudioData, Qs, FREQs);

nvars = size(xUB, 1);

[x,fval,exitflag] = particleswarm(fun, nvars, xLB, xUB, options)
save('RedToBlueDrumsNormalisedMixParameters.mat', 'x', 'fval', 'exitflag');

[BadMix, GoodMix]  = MixAudioEQDRCParticleSwarm(AudioData, x, Qs, FREQs);

audiowrite('RedToBlueDrumsMixedNormalised.wav', GoodMix, 44100);
audiowrite('RedToBlueDrumsNotMixedNormalised.wav', BadMix, 44100);

clearvars;

load('RedToBlueGuitarsNormalised.mat');

Qs = [1 0.6 0.3 0.2 0.2 1];
FREQs = [75 100 250 750 2500 7500];

eqGainUB = zeros(size(AudioData, 2) * 6 , 1);
eqGainUB(1:(size(AudioData, 2) * 6 )) = 6;

eqGainLB = zeros(size(AudioData, 2) * 6, 1);
eqGainLB(1:(size(AudioData, 2) * 6)) = -6;

ratioUB = zeros(size(AudioData, 2), 1);
ratioUB(1:(size(AudioData, 2))) = 6;

ratioLB = zeros(size(AudioData, 2), 1);
ratioLB(1:(size(AudioData, 2))) = 1.0;

thresholdUB = zeros(size(AudioData, 2), 1);
thresholdUB(1:(size(AudioData, 2))) = 0;

thresholdLB = zeros(size(AudioData, 2), 1);
thresholdLB(1:(size(AudioData, 2))) = -30;

tauAttackUB = zeros(size(AudioData, 2), 1);
tauAttackUB(1:(size(AudioData, 2))) = 0.25;

tauAttackLB = zeros(size(AudioData, 2), 1);
tauAttackLB(1:(size(AudioData, 2))) = 0.005;

tauReleaseUB = zeros(size(AudioData, 2), 1);
tauReleaseUB(1:(size(AudioData, 2))) = 3.0;

tauReleaseLB = zeros(size(AudioData, 2), 1);
tauReleaseLB(1:(size(AudioData, 2))) = 0.005;

xUB = [eqGainUB; ratioUB; thresholdUB; tauAttackUB; tauReleaseUB];
xLB = [eqGainLB; ratioLB; thresholdLB; tauAttackLB; tauReleaseLB];

options = optimoptions('particleswarm', 'Display', 'iter', 'UseParallel', true, 'FunctionTolerance', 0.05, 'ObjectiveLimit', 0);

fun = @(x)MaskingMinimisationFunctionNegativeSMR(x, AudioData, Qs, FREQs);
nvars = size(xUB, 1);

[x,fval,exitflag] = particleswarm(fun, nvars, xLB, xUB, options)
save('RedToBlueGuitarsNormalisedMixParameters.mat', 'x', 'fval', 'exitflag');

[BadMix, GoodMix]  = MixAudioEQDRCParticleSwarm(AudioData, x, Qs, FREQs);

audiowrite('RedToBlueGuitarsMixedNormalised.wav', GoodMix, 44100);
audiowrite('RedToBlueGuitarsNotMixedNormalised.wav', BadMix, 44100);
