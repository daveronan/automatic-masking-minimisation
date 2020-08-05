addpath(genpath('/import/c4dm-scratch/davidr/BayesianMixing'))
load('LeadMeDrumsNormalised.mat');
 
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
save('LeadMeDrumsNormalisedMixParameters.mat', 'x', 'fval', 'exitflag');

[BadMix, GoodMix]  = MixAudioEQDRCParticleSwarm(AudioData, x, Qs, FREQs);

audiowrite('LeadMeDrumsMixedNormalised.wav', GoodMix, 44100);
audiowrite('LeadMeDrumsNotMixedNormalised.wav', BadMix, 44100);

clearvars;

load('LeadMeVocalsNormalised.mat');

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
save('LeadMeVocalsNormalisedMixParameters.mat', 'x', 'fval', 'exitflag');

[BadMix, GoodMix]  = MixAudioEQDRCParticleSwarm(AudioData, x, Qs, FREQs);

audiowrite('LeadMeVocalsMixedNormalised.wav', GoodMix, 44100);
audiowrite('LeadMeVocalsNotMixedNormalised.wav', BadMix, 44100);

clearvars;

load('LeadMeKeysNormalised.mat');

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
save('LeadMeKeysNormalisedMixParameters.mat', 'x', 'fval', 'exitflag');

[BadMix, GoodMix]  = MixAudioEQDRCParticleSwarm(AudioData, x, Qs, FREQs);

audiowrite('LeadMeKeysMixedNormalised.wav', GoodMix, 44100);
audiowrite('LeadMeKeysNotMixedNormalised.wav', BadMix, 44100);

clearvars;

load('LeadMeGuitarsNormalised.mat');

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
save('LeadMeGuitarsNormalisedMixParameters.mat', 'x', 'fval', 'exitflag');

[BadMix, GoodMix]  = MixAudioEQDRCParticleSwarm(AudioData, x, Qs, FREQs);

audiowrite('LeadMeGuitarsMixedNormalised.wav', GoodMix, 44100);
audiowrite('LeadMeGuitarsNotMixedNormalised.wav', BadMix, 44100);
